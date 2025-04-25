using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Include this to use UI Text components

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton to access the GameManager from anywhere
    public int score = 0;               // Player's score
    public TMP_Text scoreText;              // Public reference to the Text UI component

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate GameManager
        }
    }

    // Method to increment the score
    public void IncrementScore(int amount)
    {
        score += amount;
        UpdateScoreText();  // Update the score display whenever the score changes
    }

    // Method to update the score text UI
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;  // Update the Text component with the current score
    }
}
