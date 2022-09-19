using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public static bool phase = true;
    private Animator anim;
    private float mesafe;
    float petrollingDistance;
    public bool isDead=false;

    public Transform rightHand;
    public GameObject fireBall;

    public Quaternion myDir;

    int wayPointIndex = 0;
    public Transform[] wayPoints;
    Vector3 wayPointTarget;

    public float triggerDistance;
    float agentReal;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agentReal = agent.stoppingDistance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        mesafe = Vector3.Distance(transform.position, player.position);
        petrollingDistance = Vector3.Distance(transform.position, wayPointTarget);

        if (phase)
        {
            EscapePhase();
        }
        else
        {
            ChasePhase();
        }
       

    }

    void ChasePhase()//Player kaçar, Enemy Kovalar DÜŞMANDÖVER
    {
        if (mesafe < triggerDistance && mesafe > agent.stoppingDistance || mesafe < triggerDistance)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
            {
                Run();
            }
        }
        else
        {
            EscapePhase();
        }

        if(mesafe <= agent.stoppingDistance && !player.GetComponent<PlayerHealth>().isDead)
        {
            Attack();
        }
    }

    void EscapePhase()//Enemy Kaçar, Player Kovalar PLAYER DÖVER
    {
        UpdateDestination();
        ItareteWaypointIndex();
    }

    void Attack()
    {
        Physics.Linecast(transform.position + new Vector3(0, 0.85f, 0), player.position + new Vector3(0, 1f, 0),out RaycastHit hit);
#if UNITY_EDITOR
Debug.DrawLine(transform.position + new Vector3(0, 0.85f, 0), player.position + new Vector3(0, 1f, 0));
#endif
        if (hit.collider.CompareTag("Player"))
        {
            anim.SetTrigger("isAttack");
            if (isDead == false)
            {
                transform.LookAt(player);
                agent.stoppingDistance = agentReal;
            }
        }
        else
        {
            agent.stoppingDistance--;
        }
    }

    void Run()
    {

        if (isDead == false)
        {
            agent.SetDestination(player.position);
            transform.LookAt(player);
        }
        anim.SetBool("isRunning", true);
    }

    public void Death()
    {
        isDead = true;
        agent.enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        KillEnemyOpenGate.totalEnemyValue--;
    }

    public void InstantiateEnemyFire()
    {
        Vector3 previousPos = player.position-transform.position;
        GameObject myFireBall = Instantiate(fireBall, rightHand.position, rightHand.localRotation);
        myFireBall.transform.rotation = transform.localRotation;
        myFireBall.GetComponent<BallMove>().target = previousPos;
    }

    void UpdateDestination()
    {
        wayPointTarget = wayPoints[wayPointIndex].position;
        if (isDead == false)
        {
            agent.SetDestination(wayPointTarget);
            transform.LookAt(wayPointTarget);
        }
        anim.SetBool("isRunning", true);
    }

    void ItareteWaypointIndex()
    {

        if (petrollingDistance <= agent.stoppingDistance+1)
        {
            wayPointIndex++;
            switch (wayPointIndex)
            {
                case 0:
                    wayPointIndex = 0;
                    break;
                case 1:
                    wayPointIndex = 1;
                    wayPointIndex++;
                    break;
                case 2:
                    wayPointIndex = 2;
                    wayPointIndex--;
                    break;
                case 3:
                    wayPointIndex = 3;
                    break;
            }
        }
        if (wayPointIndex == wayPoints.Length)
        {
            wayPointIndex = 0;
        }
    }
}
