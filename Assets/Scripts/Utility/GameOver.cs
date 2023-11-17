using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    private void Start()
    {
        gameOver.SetActive(false);
        Time.timeScale = 1;
    }

    public void OverCheck()
    {
        if (PlayerHealth.health == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetFloat("high_score", ScoringSystem.high_score);
        SceneManager.LoadScene("Game");
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("high_score", ScoringSystem.high_score);
        Application.Quit();
    }
}
