using UnityEngine;

// Sends the player back to a checkpoint when they touch the trap.
public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

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
