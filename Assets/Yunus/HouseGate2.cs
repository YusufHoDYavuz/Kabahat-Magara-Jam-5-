using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGate2 : MonoBehaviour
{
    SkinnedMeshRenderer smr;
    GameObject smrRoof;
    GameObject smrRoof2;
    bool state;
    float value;

    private void Start()
    {
        value = 1;
        state = false;
        smr = GetComponent<SkinnedMeshRenderer>();
        smrRoof = transform.parent.GetChild(2).gameObject;
        smrRoof2 = transform.parent.GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            state = true;           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            state = false;
        }
    }

    private void Update()
    {
        if(state)
        {
            value = Mathf.Lerp(value, 101, value * 0.001f);
            smr.SetBlendShapeWeight(0, value);
            smrRoof.SetActive(false);
            smrRoof2.SetActive(false);
        }
        else
        {
            value = Mathf.Lerp(value, 1, value * 0.001f);
            smr.SetBlendShapeWeight(0, value);
            smrRoof.SetActive(true);
            smrRoof2.SetActive(true);

        }
    }
}
