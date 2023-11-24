using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject target;
    public GameObject Inky;
    public GameObject Clyde;
    public GameObject Blinky;
    public GameObject Pinky;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target.transform.position = teleportTarget.transform.position;
            FindFirstObjectByType<AudioManager>().Play("teleport");
        }
        if (other.CompareTag("Inky"))
        {
            Inky.transform.position = teleportTarget.transform.position;
        }
        if (other.CompareTag("Pinky"))
        {
            Pinky.transform.position = teleportTarget.transform.position;
        }
        if (other.CompareTag("Blinky"))
        {
            Blinky.transform.position = teleportTarget.transform.position;
        }
        if (other.CompareTag("Clyde"))
        {
            Clyde.transform.position = teleportTarget.transform.position;
        }
    }
}
