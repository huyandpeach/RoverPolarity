using UnityEngine;

public class PolaritySplit : MonoBehaviour
{
    [SerializeField] private KeyCode splitKey = KeyCode.E;
    [SerializeField] private float splitDuration = 5f;
    [SerializeField] private Vector2 cloneSpawnOffset = new Vector2(0f, 0.05f);

    private PlayerState playerState;
    private SpriteRenderer spriteRenderer;
    private GameObject activeClone;
    private float splitTimer;
    private bool isSplit;

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(splitKey))
        {
            if (isSplit)
            {
                Merge();
            }
            else
            {
                Split();
            }
        }

        if (!isSplit)
            return;

        splitTimer -= Time.deltaTime;
        if (splitTimer <= 0f)
        {
            Merge();
        }
    }

    private void Split()
    {
        if (playerState == null || playerState.currentState != PlayerState.State.Umbra)
        {
            Debug.Log("Switch to Umbra before splitting.");
            return;
        }

        activeClone = CreateUmbraClone();
        isSplit = true;
        splitTimer = splitDuration;

        playerState.SetState(PlayerState.State.Lumis);
        playerState.SetSwitchLocked(true);

        Debug.Log("Polarity Split started.");
    }

    private GameObject CreateUmbraClone()
    {
        GameObject clone = new GameObject("Umbra Clone");
        clone.transform.position = transform.position + (Vector3)cloneSpawnOffset;
        clone.transform.rotation = transform.rotation;

        SpriteRenderer cloneRenderer = clone.AddComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            cloneRenderer.sprite = spriteRenderer.sprite;
            cloneRenderer.sortingLayerID = spriteRenderer.sortingLayerID;
            cloneRenderer.sortingOrder = spriteRenderer.sortingOrder - 1;
        }

        clone.AddComponent<UmbraClone>().Setup(cloneRenderer.sprite, transform.localScale);

        Rigidbody2D cloneBody = clone.AddComponent<Rigidbody2D>();
        cloneBody.bodyType = RigidbodyType2D.Kinematic;
        cloneBody.gravityScale = 0f;

        Collider2D playerCollider = GetComponent<Collider2D>();
        if (playerCollider is BoxCollider2D playerBox)
        {
            BoxCollider2D cloneCollider = clone.AddComponent<BoxCollider2D>();
            cloneCollider.size = playerBox.size;
            cloneCollider.offset = playerBox.offset;
            cloneCollider.isTrigger = false;
        }
        else
        {
            CircleCollider2D cloneCollider = clone.AddComponent<CircleCollider2D>();
            cloneCollider.radius = 0.35f;
            cloneCollider.isTrigger = false;
        }

        return clone;
    }

    private void Merge()
    {
        if (!isSplit && activeClone == null)
            return;

        if (activeClone != null)
        {
            Destroy(activeClone);
            activeClone = null;
        }

        isSplit = false;

        if (playerState != null)
        {
            playerState.SetSwitchLocked(false);
        }

        Debug.Log("Polarity Split ended.");
    }

    public void ForceMerge()
    {
        Merge();
    }
}
