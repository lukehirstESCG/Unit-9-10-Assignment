using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject IntroScreen;
    public GameObject GhostPen;
    public GameObject ReadyText;
    public GameObject EText;

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
        StartCoroutine(Ready());
        Destroy(GameObject.Find("GhostpenGate"), 5);
    }

    public IEnumerator Ready()
    {
        ReadyText.SetActive(true);
        EText.SetActive(true);
        yield return new WaitForSeconds(2);
        ReadyText.SetActive(false);
        EText.SetActive(false);
    }
}
