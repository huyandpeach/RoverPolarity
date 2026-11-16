using UnityEngine;

public class LightReceiver : MonoBehaviour
{
    [SerializeField] private Door targetDoor;
    [SerializeField] private bool startsActivated;
    [SerializeField] private Color inactiveColor = new Color(0.9f, 0.8f, 0.25f);
    [SerializeField] private Color activeColor = new Color(0.2f, 0.9f, 1f);

    private SpriteRenderer spriteRenderer;
    private bool isActivated;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetActivated(startsActivated);
    }

    public void Activate()
    {
        SetActivated(true);
        Debug.Log("Light Receiver activated.");
    }

    private void SetActivated(bool activated)
    {
        isActivated = activated;

        if (targetDoor != null)
        {
            targetDoor.SetOpen(isActivated);
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = isActivated ? activeColor : inactiveColor;
        }
    }
}
