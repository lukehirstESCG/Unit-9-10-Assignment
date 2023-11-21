using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] pacs;
    public GameObject gameOverScreen;
    public GameObject MainUI;
    public GameObject target;
    public TextMeshProUGUI lives;
    public int livesCount;

    void Start()
    {
        livesCount = 5;
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        lives.text = livesCount.ToString("Lives: " + livesCount);
        if (livesCount == 0)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            MainUI.SetActive(false);
        }

    }

    public void Health()
    {
        for (int i = 0; i == 5; i++)
        {
            pacs[i].SetActive(true);
        }
        
        if (livesCount > 0)
        {
            pacs[livesCount - 1].SetActive(false);
            lives.text = livesCount.ToString("Lives: " + livesCount);
        }
    }
}
