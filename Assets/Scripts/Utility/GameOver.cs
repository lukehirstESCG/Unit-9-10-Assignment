using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject MainUI;
    public PlayerHealth pHealth;

    private void Start()
    {
        gameOver.SetActive(false);
        Time.timeScale = 1;
    }

    // Player is dead, and ran out of lives.
    public void Dead()
    {
        gameOver.SetActive(true);
        MainUI.SetActive(false);
        Time.timeScale = 0;
    }

    // Reload the game, but delete the Lives PlayerPrefs.
    public void SaveScore()
    {
        PlayerPrefs.DeleteKey("Lives");
        SceneManager.LoadScene("Game");
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("Lives");
        Application.Quit();
    }
}