using UnityEngine;

// Adds a state-switch lock while the player is inside this zone.
public class StateChangeLockZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerState playerState = other.GetComponent<PlayerState>();
        if (playerState != null)
        {
            playerState.AddZoneSwitchLock();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerState playerState = other.GetComponent<PlayerState>();
        if (playerState != null)
        {
            playerState.RemoveZoneSwitchLock();
        }
    }
}
