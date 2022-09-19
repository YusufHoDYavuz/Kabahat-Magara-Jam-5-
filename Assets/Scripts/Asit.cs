using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asit : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().health=0;
            other.GetComponent<PlayerHealth>().PlayerHealthDown();
        }
    }
}
