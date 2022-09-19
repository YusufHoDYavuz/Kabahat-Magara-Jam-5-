using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGeneral : MonoBehaviour
{
    public float attackSpeed;
    public bool isSharp;
    public GameObject image;
    public AudioSource enerjiSes;

    public Material sOn, sOff;

    private void LateUpdate()
    {
        if (EnemyAI.phase)
        {
            GetComponent<Renderer>().material = sOn;
            image.gameObject.SetActive(true);
            enerjiSes.Play();
        }
        else
        {
 
            GetComponent<Renderer>().material = sOff;
            image.gameObject.SetActive(false);
        }
    }
}
