using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool Protected = false;
    public bool Powered = false;
    public float powerTimer = 10;

    public void CheckForPower()
    {
        if (!Powered)
        {
            StartCoroutine(PacmanPower());
            Powered = true;
        }
    }

    IEnumerator PacmanPower()
    {
        Protected = true;
        yield return new WaitForSeconds(powerTimer);
        Protected = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            CheckForPower();
            Destroy(GameObject.Find("PowerUp"), 10);
        }
    }
}
