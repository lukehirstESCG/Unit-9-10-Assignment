using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    public bool Protected = false;
    public bool Powered = false;
    public float speed = 500;
    public GameObject Pacman;
    public static PowerUpSystem instance;
    public float powerTimer = 10;

    private void Start()
    {
        Protected = false;
        Powered = false;
    }

    public void CheckForPower()
    {
        if (!Powered)
        {
            StartCoroutine(PacmanPower());
            Powered = true;
        }
    }

    public IEnumerator PacmanPower()
    {
        Protected = true;
        Powered = true;
        speed = speed * 2;
        yield return new WaitForSeconds(powerTimer);
        speed = 100;
        Protected = false;
        Powered = false;
    }
}
