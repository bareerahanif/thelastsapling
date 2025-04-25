using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetectionAndEndScreen : MonoBehaviour
{
    public float fallThreshold = -10f;  
    public GameObject endScreen;  

    void Start()
    {
        if (endScreen != null)
        {
            endScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            PlayerPrefs.SetString("currentLevel", SceneManager.GetActiveScene().name);

            TriggerEndScreen();  
        }
    }

    void TriggerEndScreen()
    {
        Time.timeScale = 0f;

        SceneManager.LoadScene("EndScreen");  
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;

        string levelName = PlayerPrefs.GetString("currentLevel");

        SceneManager.LoadScene(levelName);  
    }

    public void GoToHomeScreen()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("HomeScreen");
    }
}
