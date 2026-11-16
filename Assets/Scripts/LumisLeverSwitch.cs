using UnityEngine;

public class LumisLeverSwitch : MonoBehaviour
{
    [SerializeField] private Door targetDoor;
    [SerializeField] private float umbraPushForce = 8f;
    [SerializeField] private float inactiveRotationZ = 35f;
    [SerializeField] private float activeRotationZ = -35f;
    [SerializeField] private Color inactiveColor = new Color(0.9f, 0.8f, 0.25f);
    [SerializeField] private Color activeColor = new Color(0.2f, 0.9f, 0.45f);

    private SpriteRenderer spriteRenderer;
    private bool isActivated;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TryUseLever(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        TryUseLever(other);
    }

    private void TryUseLever(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerState playerState = other.GetComponent<PlayerState>();
        if (playerState == null)
            return;

        if (playerState.currentState == PlayerState.State.Lumis)
        {
            ActivateLever();
            return;
        }

        PushUmbraAway(other);
    }

    private void ActivateLever()
    {
        if (isActivated)
            return;

        isActivated = true;

        if (targetDoor != null)
        {
            targetDoor.SetOpen(true);
        }

        UpdateVisual();
    }

    private void PushUmbraAway(Collider2D other)
    {
        Rigidbody2D playerBody = other.GetComponent<Rigidbody2D>();
        if (playerBody == null)
            return;

        Vector2 pushDirection = (other.transform.position - transform.position).normalized;
        if (pushDirection == Vector2.zero)
        {
            pushDirection = Vector2.up;
        }

        playerBody.linearVelocity = new Vector2(pushDirection.x * umbraPushForce, Mathf.Max(playerBody.linearVelocity.y, umbraPushForce * 0.5f));
    }

    private void UpdateVisual()
    {
        transform.localRotation = isActivated
            ? Quaternion.Euler(0f, 0f, activeRotationZ)
            : Quaternion.Euler(0f, 0f, inactiveRotationZ);

        if (spriteRenderer != null)
        {
            spriteRenderer.color = isActivated ? activeColor : inactiveColor;
        }
    }
}
