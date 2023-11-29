using TMPro;
using UnityEngine;

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
        // Do we have a high_score?
        if (PlayerPrefs.HasKey("high_score"))
        {
            high_score = PlayerPrefs.GetInt("high_score");
            score = 0;
        }
        // Set the high_score to 0.
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
        CheckForScore();
    }

    // Update the score if it is higher than the high_score
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

    // Handles the score check system.
    public void Score()
    {
        if (score >= 650 && completed == false)
        {
            Complete();
            completed = true;
        }
    }

    // Check if the high_score has been deleted or not.
    public void CheckForScore()
    {
        if (PlayerPrefs.HasKey("high_score"))
        {
            high_score = PlayerPrefs.GetInt("high_score");
            highScoreText.text = "High Score: " + high_score;
        }
        else
        {
            high_score = 0;
        }    
    }

    // Deletes the high score.
    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteKey("high_score");
        high_score = 0;
        highScoreText.text = "High Score: " + high_score;
    }

    // Completed the game.
    public void Complete()
    {
        complete.GameComplete();
        AudioManager.manager.Play("winner");
    }

    private void OnApplicationQuit()
    {
        Application.Quit();
    }
}