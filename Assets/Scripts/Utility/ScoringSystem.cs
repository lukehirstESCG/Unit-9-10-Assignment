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
    public bool completed = false;
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
            completed = false;
        }
    }

    void Update()
    {
        UpdateScore();
        Score();
    }

    void UpdateScore()
    {
        if (score > high_score)
        {
            high_score = score;
            PlayerPrefs.SetInt("high_score", high_score);
        }
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + high_score;
    }

    public void Score()
    {
        if (score >= 650 && completed == false)
        {
            Complete();
            completed = true;
        }
    }

    public void Complete()
    {
        complete.GameComplete();
        FindFirstObjectByType<AudioManager>().Play("winner");
    }

    private void OnApplicationQuit()
    {
        Application.Quit();
    }
}