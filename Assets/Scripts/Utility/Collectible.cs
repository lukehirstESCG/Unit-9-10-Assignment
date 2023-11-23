using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoringSystem.score = ScoringSystem.score + 10;
            PlayerPrefs.SetInt("score", ScoringSystem.score);
            ScoringSystem.high_score += ScoringSystem.score;
            Destroy(gameObject);
        }
    }
}
