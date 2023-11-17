using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public GameObject pac0, pac1, pac2, pac3, pac4;
    public GameObject gameOverscreen;
    public TextMeshProUGUI healthText;
    public static int health;

    private void Start()
    {
        health = 5;
        healthText.text = health.ToString("Lives: " + health);
        pac0.SetActive(true);
        pac1.SetActive(true);
        pac2.SetActive(true);
        pac3.SetActive(true);
        pac4.SetActive(true);
        gameOverscreen.SetActive(false);
    }

    private void Update()
    {
        Health();
        healthText.text = health.ToString("Lives: " + health);
    }

    void Health()
    {
        switch (health)
        {
            case 5:
                pac0.SetActive(true);
                pac1.SetActive(true);
                pac2.SetActive(true);
                pac3.SetActive(true);
                pac4.SetActive(true);
                health = 5;
                break;
            case 4:
                pac0.SetActive(true);
                pac1.SetActive(true);
                pac2.SetActive(true);
                pac3.SetActive(true);
                pac4.SetActive(false);
                health = 4;
                break;
            case 3:
                pac0.SetActive(true);
                pac1.SetActive(true);
                pac2.SetActive(true);
                pac3.SetActive(false);
                pac4.SetActive(false);
                health = 3;
                break;
            case 2:
                pac0.SetActive(true);
                pac1.SetActive(true);
                pac2.SetActive(false);
                pac3.SetActive(false);
                pac4.SetActive(false);
                health = 2;
                break;
            case 1:
                pac0.SetActive(true);
                pac1.SetActive(false);
                pac2.SetActive(false);
                pac3.SetActive(false);
                pac4.SetActive(false);
                health = 1;
                break;
            default:
                pac0.SetActive(false);
                pac1.SetActive(false);
                pac2.SetActive(false);
                pac3.SetActive(false);
                pac4.SetActive(false);
                health = 0;
                break;
        }
    }
}
