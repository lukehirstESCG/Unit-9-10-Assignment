using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public static int score;
    public static int scoreTotal = 50;
    public static int high_score;
    private int games = 0;
    public CompletedGame complete;

    public void Start()
    {
        high_score = PlayerPrefs.GetInt("high_score", high_score);
        highScoreText.text = "High Score: " + high_score;
        games = 0;
        score = 0;

        PlayerPrefs.GetInt("games", games);

        if (PlayerPrefs.HasKey("games"))
        {
            games = PlayerPrefs.GetInt("games");
            games += 1;
            PlayerPrefs.SetInt("games", games);
        }
        else
        {
            PlayerPrefs.SetInt("games", 1);
        }
    }

    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + score;
        scoreTotal = score;
    }

    public void Score()
    {
        if (score > high_score)
        {
            high_score = score;
            highScoreText.text = "High Score: " + high_score;
            PlayerPrefs.SetInt("high_score", high_score);
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
        }
        if (score > scoreTotal)
        {
            Complete();
        }
    }

    public void Complete()
    {
        score = scoreTotal;
        complete.GameComplete();
    }

    public void LoadScore()
    {
        high_score = PlayerPrefs.GetInt("high_score");
        highScoreText.text = high_score.ToString();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("high_score", high_score);
        PlayerPrefs.Save();
        Application.Quit();
    }
}
