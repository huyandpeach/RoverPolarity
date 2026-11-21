using UnityEngine;

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
