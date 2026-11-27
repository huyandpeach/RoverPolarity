using System.Collections;
using UnityEngine;

// Pauses the player, waits, and returns them to the latest checkpoint.
public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform startingPoint;
    [SerializeField, Min(0f)] private float respawnDelay = 2f;

    private Rigidbody2D body;
    private Vector3 respawnPosition;
    private bool isWaitingForRespawn;
    private bool wasBodySimulated;
    private Behaviour[] playerControls;
    private bool[] controlsWereEnabled;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        respawnPosition = startingPoint != null ? startingPoint.position : transform.position;
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        if (isWaitingForRespawn)
            return;

        respawnPosition = checkpointPosition;
        Debug.Log("Checkpoint saved: " + respawnPosition);
    }

    public void Respawn()
    {
        if (isWaitingForRespawn)
            return;

        // Merge the clone and freeze controls and physics during the delay.
        isWaitingForRespawn = true;
        MergeSplit();
        SetControlsPaused(true);

        if (body != null)
        {
            wasBodySimulated = body.simulated;
            body.linearVelocity = Vector2.zero;
            body.angularVelocity = 0f;
            body.simulated = false;
        }

        StartCoroutine(WaitForRespawn());
    }

    private IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(Mathf.Max(0f, respawnDelay));

        MoveToCheckpoint();
        RestoreAfterRespawn();
    }

    private void MergeSplit()
    {
        PolaritySplit polaritySplit = GetComponent<PolaritySplit>();
        if (polaritySplit != null)
        {
            polaritySplit.ForceMerge();
        }
    }

    private void MoveToCheckpoint()
    {
        transform.position = respawnPosition;

        if (body != null)
        {
            body.linearVelocity = Vector2.zero;
            body.angularVelocity = 0f;
        }
    }

    private void SetControlsPaused(bool paused)
    {
        if (paused)
        {
            playerControls = new Behaviour[]
            {
                GetComponent<PlayerMovement>(),
                GetComponent<PlayerState>(),
                GetComponent<PolaritySplit>(),
                GetComponent<LumisLightShooter>()
            };
            // Remember which controls were enabled before respawning.
            controlsWereEnabled = new bool[playerControls.Length];

            for (int i = 0; i < playerControls.Length; i++)
            {
                if (playerControls[i] == null)
                    continue;

                controlsWereEnabled[i] = playerControls[i].enabled;
                playerControls[i].enabled = false;
            }
        }
        else if (playerControls != null)
        {
            for (int i = 0; i < playerControls.Length; i++)
            {
                if (playerControls[i] != null)
                {
                    playerControls[i].enabled = controlsWereEnabled[i];
                }
            }
        }
    }

    private void RestoreAfterRespawn()
    {
        if (body != null)
        {
            body.simulated = wasBodySimulated;
        }

        SetControlsPaused(false);
        isWaitingForRespawn = false;
    }

    // Restore the player if this component is disabled during the delay.
    private void OnDisable()
    {
        if (!isWaitingForRespawn)
            return;

        StopAllCoroutines();
        RestoreAfterRespawn();
    }
}
