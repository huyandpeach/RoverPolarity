using UnityEngine;

// Identifies the stationary clone as Umbra and sets up its appearance.
public class UmbraClone : MonoBehaviour
{
    public PlayerState.State State => PlayerState.State.Umbra;

    public void Setup(Sprite playerSprite, Vector3 playerScale)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = playerSprite;
            spriteRenderer.color = new Color(0.4f, 0f, 0.6f, 0.75f);
        }

        transform.localScale = playerScale;
    }
}
