using UnityEngine;

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

        Vector3 checkpointPosition = respawnPoint != null ? respawnPoint.position : transform.position;
        playerRespawn.SetCheckpoint(checkpointPosition);
    }
}
