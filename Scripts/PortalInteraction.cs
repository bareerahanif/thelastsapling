using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // For TextMeshPro UI

public class PortalInteraction : MonoBehaviour
{
    public GameObject explosionEffect;  // Explosion effect when entering the portal
    public TMP_Text portalMessageText;  // Reference to the UI text element for messages
    public string nextSceneName;  // This will be set dynamically in the Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the robot has been killed
            if (RobotEnemy.isRobotDead)
            {
                // Instantiate explosion effect
                if (explosionEffect != null)
                {
                    Instantiate(explosionEffect, transform.position, Quaternion.identity);
                }

                // Start the scene transition after the explosion effect
                StartCoroutine(LoadNextLevelAfterEffect());

                // Hide any portal messages
                portalMessageText.text = "";
            }
            else
            {
                // Display the message to defeat the robot first
                portalMessageText.text = "Defeat the robot first!";
            }
        }
    }

    private IEnumerator LoadNextLevelAfterEffect()
    {
        // Wait for the explosion effect duration before loading the next level
        yield return new WaitForSeconds(2f);

        // Load the next scene based on the Inspector setting
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name not set in Inspector!");
        }
    }
}
