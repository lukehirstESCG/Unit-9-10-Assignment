using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedGame : MonoBehaviour
{
    public static CompletedGame instance;
    public GameObject mainUI;
    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
    }

    public void GameComplete()
    {
        mainUI.SetActive(false);
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        PlayerPrefs.DeleteKey("Lives");
        SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu()
    {
        PlayerPrefs.DeleteKey("Lives");
        SceneManager.LoadScene("FrontEnd");
    }
}