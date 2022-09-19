using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WallBomb : MonoBehaviour
{
    public float force;
    public float radius;

    public Collider[] colliders;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            if (other.GetComponent<SwordGeneral>().isSharp)
            {
                StartCoroutine(destroyWall());
                Destroy(transform.parent.gameObject, 5);
            }
        }
    }

    IEnumerator destroyWall()
    {
        yield return new WaitForSeconds(0.3f);
        foreach (Collider collider in colliders)
        {
            collider.gameObject.AddComponent<Rigidbody>();
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            rb.useGravity = true;
            transform.GetComponentInParent<NavMeshObstacle>().carving = false;
        }
    }
}
