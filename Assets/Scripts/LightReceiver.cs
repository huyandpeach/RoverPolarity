using UnityEngine;

// Opens the linked door when activated by a light projectile.
public class LightReceiver : MonoBehaviour
{
    [SerializeField] private Door targetDoor;
    [SerializeField] private bool startsActivated;
    [SerializeField] private Color inactiveColor = new Color(0.9f, 0.8f, 0.25f);
    [SerializeField] private Color activeColor = new Color(0.2f, 0.9f, 1f);

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Apply the receiver state after the door has initialized.
    private void Start()
    {
        SetActivated(startsActivated);
    }

    public void Activate()
    {
        SetActivated(true);
        Debug.Log("Light Receiver activated.");
    }

    private void SetActivated(bool activated)
    {
        if (targetDoor != null)
        {
            targetDoor.SetOpen(activated);
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = activated ? activeColor : inactiveColor;
        }
    }
}
