using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public Image pac0, pac1, pac2, pac3, pac4;
    public GameObject gameOverscreen;
    public static int health;

    private void Start()
    {
        health = 5;
        pac0.enabled = true;
        pac1.enabled = true;
        pac2.enabled = true;
        pac3.enabled = true;
        pac4.enabled = true;
        gameOverscreen.SetActive(false);
    }

    private void Update()
    {
        Health();
    }

    void Health()
    {
        switch (health)
        {
            case 5:
                pac0.enabled = true;
                pac1.enabled = true;
                pac2.enabled = true;
                pac3.enabled = true;
                pac4.enabled = true;
                break;
            case 4:
                pac0.enabled = true;
                pac1.enabled = true;
                pac2.enabled = true;
                pac3.enabled = true;
                pac4.enabled = false;
                break;
            case 3:
                pac0.enabled = true;
                pac1.enabled = true;
                pac2.enabled = true;
                pac3.enabled = false;
                pac4.enabled = false;
                break;
            case 2:
                pac0.enabled = true;
                pac1.enabled = true;
                pac2.enabled = false;
                pac3.enabled = false;
                pac4.enabled = false;
                break;
            case 1:
                pac0.enabled = true;
                pac1.enabled = false;
                pac2.enabled = false;
                pac3.enabled = false;
                pac4.enabled = false;
                break;
            default:
                pac0.enabled = false;
                pac1.enabled = false;
                pac2.enabled = false;
                pac3.enabled = false;
                pac4.enabled = false;
                gameOverscreen.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
}
