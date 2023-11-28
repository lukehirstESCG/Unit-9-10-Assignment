using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float protectedTime = 1;
    public float livesCount = 5;
    public float maxHealth = 100;
    public float damage = 20;
    public float deathLength = 1;
    public bool Protected = false;
    public Image healthBar;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI healthText;
    public GameOver over;
    public GameObject Pacman;

    private void Start()
    {
        // Does the PlayerPrefs contain the lives key?
        if (PlayerPrefs.HasKey("Lives"))
        {
            livesCount = PlayerPrefs.GetFloat("Lives", livesCount);
        }
        else
        // Set the default lives
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
        // Is the player NOT protected?
        if (!Protected)
        {
            health -= damage;
            StartCoroutine(DamageCooldown());
            healthText.text = "Health: " + health;
        }
        // Has the player run out of health?
        if (health <= 0)
        {
            RemoveLife();
            StartCoroutine(Death());
        }
    }

    // Dead
    public IEnumerator Death()
    {
        Destroy(Pacman);
        AudioManager.manager.Play("dead");
        yield return new WaitForSeconds(deathLength);
        SceneManager.LoadScene("Game");
        AudioManager.manager.Stop("dead");
    }

    // Protects the player for 1 second.
    IEnumerator DamageCooldown()
    {
        Protected = true;
        yield return new WaitForSeconds(protectedTime);
        Protected = false;
    }

    // Player has died once, lose a life.
    public void RemoveLife()
    {
        livesCount -= 1;
        PlayerPrefs.SetFloat("Lives", livesCount);
        health = 100;
        ScoringSystem.score = 0;
        lives.text = "Lives: " + livesCount;
        healthText.text = "Health: " + health;
        // Has the player run out of lives?
        if (livesCount <= 0)
        {
            Dead();
            AudioManager.manager.Play("dead");
        }
    }

    // Player ran out of lives.
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