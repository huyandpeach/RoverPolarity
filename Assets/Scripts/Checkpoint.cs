using UnityEngine;

// Saves this checkpoint as the player's next respawn location.
public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
        if (playerRespawn == null)
            return;

        // Use the checkpoint object itself when no separate respawn point is assigned.
        Vector3 checkpointPosition = respawnPoint != null ? respawnPoint.position : transform.position;
        playerRespawn.SetCheckpoint(checkpointPosition);
    }
}
