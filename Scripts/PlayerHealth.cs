using UnityEngine;
using TMPro;  // For TextMeshPro UI
using UnityEngine.SceneManagement;  // To manage scene transitions

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;         // Maximum health of the player
    public int currentHealth;           // Current health of the player
    public TMP_Text healthText;         // Reference to the TMP_Text UI component for displaying health
    public int damagePerSecond = 5;    // Damage dealt every second while touching the robot
    public string endScreenScene = "EndScreen";  // The name of the End Screen scene

    private bool isTouchingEnemy = false;  // To track if the player is touching an enemy

    void Start()
    {
        currentHealth = maxHealth;  // Set current health to max at the start
        UpdateHealthUI();           // Update the health UI on start
    }

    void Update()
    {
        // If the player is continuously touching the robot, decrease health over time
        if (isTouchingEnemy)
        {
            TakeDamage((int)(damagePerSecond * Time.deltaTime));  // Damage over time, cast to int
        }
    }

    // Method to decrease the player's health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            GameOver();  // Trigger Game Over when health reaches 0
        }
        UpdateHealthUI();
    }

    // Method to update the health UI
    void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth;  // Update the TMP_Text component with the current health
    }

    // Detect if the player is touching an enemy
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Robot") || collision.gameObject.CompareTag("Enemy"))
        {
            isTouchingEnemy = true;  // Start taking damage when touching the enemy
        }
    }

    // Detect when the player stops touching the enemy
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Robot") || collision.gameObject.CompareTag("Enemy"))
        {
            isTouchingEnemy = false;  // Stop taking damage when no longer touching the enemy
        }
    }

    // Trigger the End Screen scene when the player's health reaches 0
    void GameOver()
    {
        // Load the End Screen scene
        SceneManager.LoadScene(endScreenScene);
    }
}
