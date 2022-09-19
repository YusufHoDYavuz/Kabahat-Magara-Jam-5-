using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeChechkPoint : MonoBehaviour
{
    public Transform checkPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkPoint.position = transform.position;
        }
    }
}
