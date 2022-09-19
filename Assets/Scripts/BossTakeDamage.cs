using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTakeDamage : MonoBehaviour
{
    bool damageTakeable;

    private void Start()
    {
        damageTakeable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sword") && other.GetComponent<SwordGeneral>().isSharp && damageTakeable)
        {
            damageTakeable = false;
            GetComponent<BossHealth>().HasarAl();
            StartCoroutine(TakeDamageDuration(other.GetComponent<SwordGeneral>().attackSpeed));
            
        }
    }


    IEnumerator TakeDamageDuration(float a)
    {
        yield return new WaitForSeconds(a);
        damageTakeable = true;
    }
}
