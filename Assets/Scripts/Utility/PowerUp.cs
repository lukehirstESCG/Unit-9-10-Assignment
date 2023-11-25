using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpSystem power;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.manager.Play("collect");
            Destroy(gameObject);
            power.CheckForPower();
            ScoringSystem.score = ScoringSystem.score += 50;
        }
    }
}
