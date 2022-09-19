using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientStart : MonoBehaviour
{
    public GameObject checkP;
    bool firstEnter;

    private void Start()
    {
        firstEnter = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            checkP.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            if (firstEnter)
            {
                firstEnter = false;
                StartCoroutine(PhaseControler());
            }
        }
    }
    IEnumerator PhaseControler()
    {
        int counter=0;
        while (counter>=0)
        {
            yield return new WaitForSeconds(1);
            counter++;
            print(counter);
            if (counter%10 == 0)
            {
                EnemyAI.phase = false;
            }
            if (counter%20 == 0)
            {
                EnemyAI.phase = true;
            }

        }
    }
}
