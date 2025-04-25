using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // Bullet speed
    public int damage = 1;     // Damage dealt to the robot

    void Start()
    {
        // Set the bullet's velocity to make it move
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;  // Move in the direction the bullet is facing
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the bullet collides with a robot
        if (collider.CompareTag("Robot"))
        {
            // Get the RobotEnemy script and call TakeDamage
            RobotEnemy robot = collider.GetComponent<RobotEnemy>();
            if (robot != null)
            {
                robot.TakeDamage(damage);
            }

            // Destroy the bullet after collision
            Destroy(gameObject);
        }
    }
}
