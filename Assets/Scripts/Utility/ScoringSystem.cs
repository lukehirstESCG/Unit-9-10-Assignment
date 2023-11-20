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
    public static int high_score;
    private int games = 0;

    public void Start()
    {
        high_score = PlayerPrefs.GetInt("high_score", high_score);
        highScoreText.text = high_score.ToString("High Score: " + high_score);
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
        scoreText.text = score.ToString("Score: " + score);
    }

    public void Score()
    {
        if (score > high_score)
        {
            high_score = score;
            highScoreText.text = "High Score: " + high_score;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("high_score", high_score);
        }
    }

    public void LoadScore()
    {
        high_score = PlayerPrefs.GetInt("high_score");
        highScoreText.text = high_score.ToString();
    }
}
