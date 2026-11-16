using UnityEngine;

public class LumisLightShooter : MonoBehaviour
{
    [SerializeField] private KeyCode shootKey = KeyCode.F;
    [SerializeField] private float projectileSpeed = 12f;
    [SerializeField] private float projectileLifetime = 2f;
    [SerializeField] private float shootCooldown = 0.25f;
    [SerializeField] private Vector2 shootOffset = new Vector2(0.6f, 0f);
    [SerializeField] private GameObject projectilePrefab;

    private PlayerState playerState;
    private float nextShootTime;
    private Vector2 aimDirection = Vector2.right;

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        UpdateAimDirection();

        if (Input.GetKeyDown(shootKey))
        {
            TryShoot();
        }
    }

    private void UpdateAimDirection()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0f)
        {
            aimDirection = Vector2.right;
        }
        else if (horizontalInput < 0f)
        {
            aimDirection = Vector2.left;
        }
    }

    private void TryShoot()
    {
        if (Time.time < nextShootTime)
            return;

        if (playerState == null || playerState.currentState != PlayerState.State.Lumis)
        {
            Debug.Log("Only Lumis can shoot light.");
            return;
        }

        nextShootTime = Time.time + shootCooldown;
        SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        Vector3 spawnPosition = transform.position + new Vector3(shootOffset.x * aimDirection.x, shootOffset.y, 0f);
        GameObject projectile = projectilePrefab != null
            ? Instantiate(projectilePrefab, spawnPosition, Quaternion.identity)
            : CreateDefaultProjectile(spawnPosition);

        LightProjectile lightProjectile = projectile.GetComponent<LightProjectile>();
        if (lightProjectile == null)
        {
            lightProjectile = projectile.AddComponent<LightProjectile>();
        }

        lightProjectile.Initialize(aimDirection, projectileSpeed, projectileLifetime, gameObject);
    }

    private GameObject CreateDefaultProjectile(Vector3 spawnPosition)
    {
        GameObject projectile = new GameObject("Lumis Light Projectile");
        projectile.transform.position = spawnPosition;

        SpriteRenderer spriteRenderer = projectile.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = LightProjectile.CreateDefaultSprite();
        spriteRenderer.color = new Color(1f, 0.95f, 0.35f);
        spriteRenderer.sortingOrder = 20;

        CircleCollider2D projectileCollider = projectile.AddComponent<CircleCollider2D>();
        projectileCollider.isTrigger = true;
        projectileCollider.radius = 0.15f;

        Rigidbody2D projectileBody = projectile.AddComponent<Rigidbody2D>();
        projectileBody.bodyType = RigidbodyType2D.Kinematic;
        projectileBody.gravityScale = 0f;

        return projectile;
    }
}
