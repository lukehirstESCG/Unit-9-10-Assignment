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

    public void Dead()
    {
        gameOver.SetActive(true);
        MainUI.SetActive(false);
        Time.timeScale = 0;
    }

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