using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject IntroScreen;
    public GameObject GhostPen;

    // Start is called before the first frame update
    void Start()
    {
        MainUI.SetActive(false);
        IntroScreen.SetActive(true);
    }

    public void GameStart()
    {
        AudioManager.manager.Play("start");
        IntroScreen.SetActive(false);
        MainUI.SetActive(true);
        Destroy(GameObject.Find("GhostpenGate"), 5);
    }
}
