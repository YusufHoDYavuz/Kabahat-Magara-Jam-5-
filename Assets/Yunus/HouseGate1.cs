using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGate1 : MonoBehaviour
{
    SkinnedMeshRenderer smr;
    bool state;
    float value;

    private void Start()
    {
        value = 1;
        state = false;
        smr = GetComponent<SkinnedMeshRenderer>();
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
        }
        else
        {
            value = Mathf.Lerp(value, 1, value * 0.001f);
            smr.SetBlendShapeWeight(0, value);
        }     
        
        //value = Mathf.Lerp(value, 101, value/1000);
    }
}
