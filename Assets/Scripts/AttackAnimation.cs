using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    private Animator anim;
    public SwordGeneral SG;
    public float saldiriHizi;
    public bool canAttack;

    private void Awake()
    {
        SG.attackSpeed = saldiriHizi;
        SG.isSharp = canAttack;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyAI.phase)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("isBasicHit");
                canAttack = true;
                SG.isSharp = canAttack;
                StartCoroutine(AttackOver());
            }
        } 
    }

    IEnumerator AttackOver()
    {
        yield return new WaitForSeconds(1.06f);
        canAttack = false;
        SG.isSharp = canAttack;
    }

}
