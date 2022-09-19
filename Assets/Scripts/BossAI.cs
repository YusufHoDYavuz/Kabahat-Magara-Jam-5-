using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    private Animator anim;
    public bool isDead=false;
    private float mesafe;
    public GameObject wife, mobilya, door, caveOutDoor;
    public float StunRepaet;
    //public float triggerDistance;



    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        InvokeRepeating(nameof(Stun), 10, StunRepaet);
    }
    private void Update()
    {
        mesafe = Vector3.Distance(transform.position, player.position);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Armature_Wolf_Rour") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Armature_Wolf_Stun")) 
        { 
            if (mesafe <= agent.stoppingDistance)
                {
                    Attack();
                }
            else
            {
                    Run();
            }
        }
    }

    void Attack()
    {
        if (GetComponent<Rigidbody>().constraints == RigidbodyConstraints.FreezeAll)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (isDead == false)
        {
            anim.SetTrigger("isAttack");
            transform.LookAt(player);
        }
    }


    void Run()
    {
        if(GetComponent<Rigidbody>().constraints == RigidbodyConstraints.FreezeAll)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        
        if (isDead == false)
        {
            agent.SetDestination(player.position);
            transform.LookAt(player);
        }
        anim.SetBool("isRunning", true);
    }

    public void Death()
    {
        anim.SetBool("CurrentDead", true);
        isDead = true;
        agent.enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<RandomLightning>().enabled = false;

        KillTheBoss();
        Destroy(gameObject, 6);
    }

    public void KillTheBoss()
    {
        wife.SetActive(true);
        mobilya.SetActive(true);

        door.SetActive(false);
        caveOutDoor.SetActive(false);

        GameObject.Find("Door").GetComponent<SoundManager>().Sound();
    }

    void Stun()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Armature_Wolf_Rour"))
        {
            anim.SetTrigger("isStun");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
            
    }
    public void Hit()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void HitEnd()
    {
        transform.GetChild(2).gameObject.SetActive(false);
    }
}
