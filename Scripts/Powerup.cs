using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int scoreIncrement = 10;       // Amount to increment score when powerup is collected

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the object colliding with the powerup is the player
        if (collider.CompareTag("Player"))
        {
            // Increment the score
            GameManager.Instance.IncrementScore(scoreIncrement);

            // Destroy the powerup from the scene after collection
            Destroy(gameObject);
        }
    }
}
