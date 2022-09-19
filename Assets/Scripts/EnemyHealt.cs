using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealt : MonoBehaviour
{
    private int health;
    private int maxHealth;
    private int damagaPoints;
    private Animator anim;
    [SerializeField]
    private int damageAmount,farkAmount;
    
    public Slider slider;
    public Camera mainCamera;
    Transform canvas;

    void Start()
    {
        anim=GetComponent<Animator>();
        mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
        health = 100;
        maxHealth = 100;
        slider.maxValue = maxHealth;
        slider.value = health;
        canvas = slider.transform.parent;
    }

    private void Update()
    {
        canvas.transform.LookAt(canvas.transform.position + mainCamera.transform.rotation * Vector3.back, mainCamera.transform.rotation * Vector3.up);
    }

    public void HasarAl()
    {
        anim.SetTrigger("isHit");
        damagaPoints = Random.Range(damageAmount - farkAmount, damageAmount + farkAmount);
        if (health > 0)
        {
            health -= damagaPoints;
            slider.value = health;
        }
        if (health <= 0)
        {
            slider.value = 0;

            if (GetComponent<EnemyAI>().isDead == false)
            {
                anim.SetTrigger("isDead");
                GetComponent<EnemyAI>().Death();
            }

        }
    }

}
