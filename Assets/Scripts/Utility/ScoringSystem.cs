using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public static int score = 0;
    public static int high_score;
    public CompletedGame complete;

    public void Start()
    {
        if (PlayerPrefs.HasKey("high_score"))
        {
            high_score = PlayerPrefs.GetInt("high_score");
            score = 0;
        }
        else
        {
            high_score = 0;
        }
    }

    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + high_score;
    }

    public void Score()
    {
        if (score > high_score)
        {
            high_score = score;
        }
        highScoreText.text = "High Score: " + high_score;
        PlayerPrefs.SetInt("high_score", high_score);

        if (!GameObject.Find("Collectible"))
        {
            Complete();
        }
    }

    public void Complete()
    {
        complete.GameComplete();
    }

    public void LoadScore()
    {
        high_score = PlayerPrefs.GetInt("high_score");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("high_score", high_score);
        Application.Quit();
    }
}