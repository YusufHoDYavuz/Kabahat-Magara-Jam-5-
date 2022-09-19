using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightning : MonoBehaviour
{
    public GameObject meteor;
    public float areaValue;
    public float repeatRate;
    public int meteorAmount;
    public float dropsecond;
    private Animator anim;


    private void Start()
    {
       
    }

    private void OnEnable()
    {
        MeteorFall(true);
        anim = GetComponent<Animator>();

    }

    public void MeteorFall(bool isOpen)
    {
        if (isOpen)
            InvokeRepeating(nameof(GenerateLightning), 2, repeatRate);
        else
            CancelInvoke(nameof(GenerateLightning));
    }


    void GenerateLightning()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Armature_Wolf_Stun"))
        {
            float x = transform.position.x;
            float z = transform.position.z;
            anim.SetTrigger("isRoar");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            for (int i = 0; i < meteorAmount; i++)
            {
                GameObject a = Instantiate(meteor, new Vector3(Random.Range(x - areaValue, x + areaValue), 6.5f, Random.Range(z - areaValue, z + areaValue)), Quaternion.identity, null);
                StartCoroutine(MeteorActive(a));
            }

        }
              
        
    }

    IEnumerator MeteorActive(GameObject a)
    {
        yield return new WaitForSeconds(dropsecond);
        a.transform.GetChild(0).gameObject.SetActive(true);
    }
}
