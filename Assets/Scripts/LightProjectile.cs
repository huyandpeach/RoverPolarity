using UnityEngine;

public class LightProjectile : MonoBehaviour
{
    private static Sprite defaultSprite;

    private Rigidbody2D body;
    private GameObject owner;
    private float destroyTime;
    private bool isInitialized;

    public static Sprite CreateDefaultSprite()
    {
        if (defaultSprite != null)
            return defaultSprite;

        const int size = 16;
        Texture2D texture = new Texture2D(size, size);
        texture.filterMode = FilterMode.Point;

        Vector2 center = new Vector2((size - 1) * 0.5f, (size - 1) * 0.5f);
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float distance = Vector2.Distance(new Vector2(x, y), center);
                Color color = distance <= 6f ? Color.white : Color.clear;
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        defaultSprite = Sprite.Create(texture, new Rect(0f, 0f, size, size), new Vector2(0.5f, 0.5f), 16f);
        return defaultSprite;
    }

    public void Initialize(Vector2 direction, float speed, float lifetime, GameObject projectileOwner)
    {
        owner = projectileOwner;
        destroyTime = Time.time + lifetime;
        isInitialized = true;

        body = GetComponent<Rigidbody2D>();
        if (body == null)
        {
            body = gameObject.AddComponent<Rigidbody2D>();
            body.bodyType = RigidbodyType2D.Kinematic;
            body.gravityScale = 0f;
        }

        body.linearVelocity = direction.normalized * speed;
    }

    private void Update()
    {
        if (isInitialized && Time.time >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == owner || other.CompareTag("Player"))
            return;

        LightReceiver receiver = other.GetComponent<LightReceiver>();
        if (receiver != null)
        {
            receiver.Activate();
            Destroy(gameObject);
            return;
        }

        if (other.GetComponent<UmbraClone>() != null)
            return;

        Destroy(gameObject);
    }
}
