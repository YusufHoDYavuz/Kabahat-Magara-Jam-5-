using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChech : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().PlayerHealthDown();
        }
    }



}
