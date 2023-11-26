using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float protectedTime = 1;
    public float livesCount = 5;
    public float maxHealth;
    public float deathLength = 1;
    public bool Protected = false;
    public Image healthBar;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI healthText;
    public GameOver over;
    public GameObject Pacman;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Lives"))
        {
            livesCount = PlayerPrefs.GetFloat("Lives", livesCount);
        }
        else
        {
            livesCount = 5;
        }
        lives.text = "Lives: " + livesCount;
        maxHealth = health;
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 100);
        healthText.text = "Health: " + health;
    }

    public void TakeDamage(float damage)
    {
        if (!Protected)
        {
            health -= damage;
            StartCoroutine(DamageCooldown());
            healthText.text = "Health: " + health;
            Debug.Log("OW!");
        }
        if (health <= 0)
        {
            RemoveLife();
            StartCoroutine(Death());
        }
    }

    public IEnumerator Death()
    {
        Destroy(Pacman);
        AudioManager.manager.Play("dead");
        yield return new WaitForSeconds(deathLength);
        SceneManager.LoadScene("Game");
    }

    IEnumerator DamageCooldown()
    {
        Protected = true;
        yield return new WaitForSeconds(protectedTime);
        Protected = false;
    }

    public void RemoveLife()
    {
        livesCount -= 1;
        PlayerPrefs.SetFloat("Lives", livesCount);
        health = 100;
        ScoringSystem.score = 0;
        lives.text = "Lives: " + livesCount;
        healthText.text = "Health: " + health;
        if (livesCount <= 0)
        {
            Dead();
            AudioManager.manager.Play("dead");
        }
    }

    public void Dead()
    {
        over.Dead();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("Lives");
        Application.Quit();
    }
}