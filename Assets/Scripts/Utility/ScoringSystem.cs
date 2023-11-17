using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score;

    private void Update()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
