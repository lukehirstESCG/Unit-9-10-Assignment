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
        // Has the player collided with the teleporter?
        if (other.CompareTag("Player"))
        {
            target.transform.position = teleportTarget.transform.position;
            FindFirstObjectByType<AudioManager>().Play("teleport");
        }
        // Blinky collided?
        else if (other.CompareTag("Inky"))
        {
            Inky.transform.position = teleportTarget.transform.position;
        }
        // Pinky collided?
        else if (other.CompareTag("Pinky"))
        {
            Pinky.transform.position = teleportTarget.transform.position;
        }
        // Blinky collided?
        else if (other.CompareTag("Blinky"))
        {
            Blinky.transform.position = teleportTarget.transform.position;
        }
        // Clyde collided?
        else if (other.CompareTag("Clyde"))
        {
            Clyde.transform.position = teleportTarget.transform.position;
        }
    }
}
