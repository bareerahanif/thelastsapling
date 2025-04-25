using UnityEngine;

public class PowerupDisplay : MonoBehaviour
{
    public GameObject powerupIconPrefab;  // The icon prefab that represents a collected powerup
    public Transform powerupContainer;    // The parent container in the UI to hold the icons

    private int powerupCount = 0;         // Number of powerups collected

    // This method will be called when the player collects a powerup
    public void AddPowerup()
    {
        // Increase the powerup count
        powerupCount++;

        // Instantiate a new powerup icon and place it under the PowerupContainer
        GameObject newIcon = Instantiate(powerupIconPrefab, powerupContainer);

        // Optionally adjust the position or spacing of the new icon
        RectTransform rect = newIcon.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(powerupCount * 50, 0); // Adjust spacing as needed
    }
}
