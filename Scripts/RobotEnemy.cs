using UnityEngine;

public class RobotEnemy : MonoBehaviour
{
    public int health = 3;              // Default health of the robot (e.g., 3 hits to kill)
    public GameObject robotDeathEffect; // Explosion or death effect when the robot dies
    public int damageToPlayer = 10;     // Damage dealt to the player when touching the robot

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component
    }

    void Update()
    {
        // Optional: Add animations for robot movement here
        // If robot is moving, play "Run" animation, else "Idle" animation
    }

    // Method to reduce the robot's health when it is shot
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Check if robot health is 0 or less and then destroy the robot
        if (health <= 0)
        {
            Die();
        }
    }

    // Method to handle the robot's death
    void Die()
    {
        if (robotDeathEffect != null)
        {
            // Instantiate death effect (e.g., explosion) at the robot's position
            Instantiate(robotDeathEffect, transform.position, Quaternion.identity);
        }

        // Destroy the robot GameObject
        Destroy(gameObject);
    }

    // When the player collides with the robot, decrease the player's health
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageToPlayer);  // Apply damage to the player
            }
        }
    }

    // Detect the robot being hit by a bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Call TakeDamage when the robot is hit by a bullet
            TakeDamage(1); // Adjust damage value based on bullet strength
            Destroy(other.gameObject); // Destroy the bullet after collision
        }
    }
}
