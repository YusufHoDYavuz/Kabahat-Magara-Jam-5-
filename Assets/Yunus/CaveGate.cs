using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveGate : MonoBehaviour
{
    public GameObject boss;
    public GameObject checkP;
    public Slider Slider;

    public GameObject beDestroy;

    private void Start()
    {
        if(boss)
            boss.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!boss.activeSelf)
            {
                checkP.transform.position = gameObject.transform.position;
                boss.SetActive(true);
                Slider.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().isTrigger = false;
            if (beDestroy)
                Destroy(beDestroy);
        }
    }
}
