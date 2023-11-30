using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGame : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject IntroScreen;
    public GameObject GhostPen;
    public TextMeshProUGUI ReadyText;
    public TextMeshProUGUI EText;
    public PlayerMovementSM playsm;
    public bool ReadyCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        MainUI.SetActive(false);
        IntroScreen.SetActive(true);
        ReadyText.enabled = false;
        EText.enabled = false;
    }

    public void GameStart()
    {
        if (ReadyCheck == false)
        {
            StartCoroutine(Ready());
            ReadyCheck = true;
        }
    }

    public IEnumerator Ready()
    {
        AudioManager.manager.Play("start");
        IntroScreen.SetActive(false);
        ReadyText.enabled = true;
        EText.enabled = true;
        playsm.Started = false;
        yield return new WaitForSeconds(3);
        ReadyText.enabled = false;
        EText.enabled = false;
        playsm.Started = true;
        MainUI.SetActive(true);
        Destroy(GameObject.Find("GhostpenGate"), 5);
    }
}
