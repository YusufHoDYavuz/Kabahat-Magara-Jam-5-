using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float damage;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //hasar alma kodu
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
