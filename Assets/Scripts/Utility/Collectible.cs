using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoringSystem.score += 10;
        Destroy(gameObject);
    }
}
