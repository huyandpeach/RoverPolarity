using UnityEngine;

// Handles player movement, jumping, animation, and sprite facing.
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int maxJumpCount = 1;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private int jumpCount;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (groundCheck == null)
        {
            Debug.LogWarning("PlayerMovement needs a Ground Check transform to detect the ground.", this);
        }
    }

    private void Update()
    {
        Move();
        bool isGrounded = IsGrounded();
        Jump(isGrounded);
        UpdateAnimator(isGrounded);
        FlipSprite();
    }

    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        body.linearVelocity = new Vector2(
            moveInput * speed,
            body.linearVelocity.y
        );
    }

    private void Jump(bool isGrounded)
    {
        // Landing resets the number of jumps available.
        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            body.linearVelocity = new Vector2(
                body.linearVelocity.x,
                jumpForce
            );

            jumpCount++;
        }
    }

    private bool IsGrounded()
    {
        if (groundCheck == null)
            return false;

        return Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    private void UpdateAnimator(bool isGrounded)
    {
        if (playerAnimator == null)
            return;

        playerAnimator.SetFloat("moveX", body.linearVelocity.x);
        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    private void FlipSprite()
    {
        if (spriteRenderer == null)
            return;

        if (body.linearVelocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (body.linearVelocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
