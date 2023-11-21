using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject target;
    public GameObject Inky;
    public GameObject Pinky;
    public GameObject Blinky;
    public GameObject Clyde;

    public void OnTriggerEnter(Collider other)
    {
        target.transform.position = teleportTarget.transform.position;

        if (other.gameObject.tag == "Blinky")
        {
            Blinky.transform.position = teleportTarget.transform.position;
        }
        if (other.gameObject.tag == "Inky")
        {
            Inky.transform.position = teleportTarget.transform.position;
        }
        if (other.gameObject.tag == "Clyde")
        {
            Clyde.transform.position = teleportTarget.transform.position;
        }
        if (other.gameObject.tag == "Pinky")
        {
            Pinky.transform.position = teleportTarget.transform.position;
        }
    }
}
