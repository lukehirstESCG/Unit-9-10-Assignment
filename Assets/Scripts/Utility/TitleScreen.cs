using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteKey("high_score");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
