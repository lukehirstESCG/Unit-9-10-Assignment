using System.Collections;
using System.Collections.Generic;
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

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        MainUI.SetActive(false);
        Time.timeScale = 0;
        AudioListener.pause = true;
        isPaused = true;
    }

    public void ResumeGame()
    {
        MainUI.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("FrontEnd");
    }

    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteKey("high_score");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
