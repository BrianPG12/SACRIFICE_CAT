using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; 
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
        {
            Time.timeScale = 0f; 
            pausePanel.SetActive(true); 
            isPaused = true;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        pausePanel.SetActive(false); 
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Main Menu"); 
    }
}
