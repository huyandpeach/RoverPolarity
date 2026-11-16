using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool startsOpen;
    [SerializeField] private Color closedColor = new Color(0.45f, 0.45f, 0.45f);
    [SerializeField] private Color openColor = new Color(0.2f, 0.9f, 0.45f, 0.45f);

    private Collider2D doorCollider;
    private SpriteRenderer spriteRenderer;
    private bool isOpen;

    private void Awake()
    {
        doorCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetOpen(startsOpen);
    }

    public void SetOpen(bool open)
    {
        isOpen = open;

        if (doorCollider != null)
        {
            doorCollider.enabled = !isOpen;
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = isOpen ? openColor : closedColor;
        }
    }

    public void Toggle()
    {
        SetOpen(!isOpen);
    }
}
