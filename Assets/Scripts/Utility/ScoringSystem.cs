using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public static TextMeshProUGUI scoreText;
    public static TextMeshProUGUI highScoreText;
    public static int score;
    public static int high_score;
    private int games = 0;

    private void Start()
    {
        ScoringSystem.high_score = PlayerPrefs.GetInt("high_score", ScoringSystem.high_score);
        ScoringSystem.highScoreText.text = ScoringSystem.high_score.ToString("High Score: " + ScoringSystem.high_score);
        games = 0;

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
    private void Update()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString("Score: " + score);

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
