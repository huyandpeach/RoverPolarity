using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform startingPoint;

    private Rigidbody2D body;
    private Vector3 respawnPosition;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        respawnPosition = startingPoint != null ? startingPoint.position : transform.position;
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        respawnPosition = checkpointPosition;
        Debug.Log("Checkpoint saved: " + respawnPosition);
    }

    public void Respawn()
    {
        PolaritySplit polaritySplit = GetComponent<PolaritySplit>();
        if (polaritySplit != null)
        {
            polaritySplit.ForceMerge();
        }

        transform.position = respawnPosition;

        if (body != null)
        {
            body.linearVelocity = Vector2.zero;
            body.angularVelocity = 0f;
        }
    }
}
