using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed;
    public Vector3 target;

    private void Start()
    {
        //BURASI DUVARA ÇARPINCA TETİKLETİLECEK VE PARTİCLE EFFECT OLACAK
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().PlayerHealthDown();
        }
        
    }

    void Update()
    {
        MoveTarget();
    }

    void MoveTarget()
    {
        transform.position += target * speed * Time.deltaTime;
    }
}
