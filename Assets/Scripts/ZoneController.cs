using UnityEngine;

// Respawns the player if they enter the zone in the wrong polarity.
public class ZoneController : MonoBehaviour
{
    [SerializeField] private PlayerState.State requiredState;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerState playerState = other.GetComponent<PlayerState>();
        if (playerState == null)
            return;

        if (playerState.currentState == requiredState)
            return;

        Debug.Log("Wrong State!");

        PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
        if (playerRespawn != null)
        {
            playerRespawn.Respawn();
            return;
        }

        // Fall back to the world origin if the player has no respawn component.
        other.transform.position = Vector3.zero;
    }
}
