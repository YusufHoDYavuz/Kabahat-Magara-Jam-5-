using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    int damagePoint;
    public Transform checkPoint;
    public GameObject darkImage;
    public Slider slider;

    [SerializeField]
    private int damageAmount, farkAmount;

    public bool isDead = false;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        slider.maxValue = health;
        slider.value = health;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            print("çalýþtý");
            transform.parent.position = checkPoint.position;
        }
    }


    public void PlayerHealthDown()
    {
        damagePoint = Random.Range(damageAmount - farkAmount, damageAmount + farkAmount);
        if (health > 0)
        {
            health -= damagePoint;
        }
        if (health <= 0)
        {
            if (isDead == false)
            {
                isDead = true;
                anim.SetTrigger("isDead");
                Dead();
            }
        }
        slider.value = health;
    }

    public void Dead()
    {
        GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(CheckPoint());
    }
   
    IEnumerator CheckPoint()
    {
        yield return new WaitForSeconds(2.5f);
        darkImage.GetComponent<Image>().color = new Color(0, 0, 0, 1);

        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("isAlive");

        yield return new WaitForSeconds(0.5f);
        transform.parent.position = checkPoint.position;
        darkImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        health = 100;
        isDead = false;
        GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
