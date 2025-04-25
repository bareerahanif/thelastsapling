using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float maxJumpHeight = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public GameObject bulletPrefab;  // Bullet prefab to instantiate when shooting
    public Transform shootingPoint;  // Where the bullet will be spawned (e.g., player’s gun)

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private float groundRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput != 0)
        {
            animator.Play("Run");
        }
        else
        {
            animator.Play("Idle");
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.Play("Jump");
        }

        if (rb.velocity.y > 0 && rb.velocity.y > maxJumpHeight)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxJumpHeight);
        }

        // Trigger the shooting animation and instantiate the bullet when 'P' is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.Play("Shoot");  // Play shooting animation

            // Instantiate the bullet and shoot it
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Instantiate the bullet at the shooting point
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
