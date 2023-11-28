using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject MainUI;
    public GameObject pauseCog;
    public bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Pause the game
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        MainUI.SetActive(false);
        Time.timeScale = 0;
        AudioListener.pause = true;
        isPaused = true;
    }

    // Resume the game
    public void ResumeGame()
    {
        MainUI.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        isPaused = false;
    }

    // Go to Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene("FrontEnd");
        PlayerPrefs.DeleteKey("Lives");
    }

    // Delete the high score
    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteKey("high_score");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
