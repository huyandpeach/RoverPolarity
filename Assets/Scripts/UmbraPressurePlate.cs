using UnityEngine;

public class UmbraPressurePlate : MonoBehaviour
{
    [SerializeField] private Door targetDoor;
    [SerializeField] private float pressSpeed = 2.5f;
    [SerializeField] private float releaseSpeed = 1.5f;
    [SerializeField] private float pressedYScale = 0.35f;
    [SerializeField] private Color releasedColor = new Color(0.45f, 0f, 0.65f);
    [SerializeField] private Color pressedColor = new Color(0.2f, 0.9f, 0.45f);

    private SpriteRenderer spriteRenderer;
    private Vector3 startScale;
    private float pressAmount;
    private float lastUmbraContactTime = -999f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startScale = transform.localScale;
        UpdateVisual();
    }

    private void Update()
    {
        bool isPressedByUmbra = Time.time - lastUmbraContactTime <= 0.1f;
        float targetAmount = isPressedByUmbra ? 1f : 0f;
        float speed = isPressedByUmbra ? pressSpeed : releaseSpeed;

        pressAmount = Mathf.MoveTowards(pressAmount, targetAmount, speed * Time.deltaTime);

        if (targetDoor != null)
        {
            targetDoor.SetOpen(pressAmount >= 1f);
        }

        UpdateVisual();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!IsUmbraSource(other))
            return;

        lastUmbraContactTime = Time.time;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!IsUmbraSource(other))
            return;

        lastUmbraContactTime = -999f;
    }

    private bool IsUmbraSource(Collider2D other)
    {
        UmbraClone umbraClone = other.GetComponent<UmbraClone>();
        if (umbraClone != null)
            return true;

        if (!other.CompareTag("Player"))
            return false;

        PlayerState playerState = other.GetComponent<PlayerState>();
        return playerState != null && playerState.currentState == PlayerState.State.Umbra;
    }

    private void UpdateVisual()
    {
        transform.localScale = new Vector3(
            startScale.x,
            Mathf.Lerp(startScale.y, startScale.y * pressedYScale, pressAmount),
            startScale.z
        );

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.Lerp(releasedColor, pressedColor, pressAmount);
        }
    }
}
