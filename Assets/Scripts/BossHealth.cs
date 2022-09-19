using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    private int health;
    //private int maxHealth;
    private int damagaPoints;
    private Animator anim;
    [SerializeField]
    private int damageAmount,farkAmount;
    public Slider slider;
    void Start()
    {
        anim=GetComponent<Animator>();
        health = 100;
        slider.maxValue = health;
        slider.value = health;
    }

    public void HasarAl()
    {
        damagaPoints = Random.Range(damageAmount - farkAmount, damageAmount + farkAmount);
        if (health > 0)
        {
            health -= damagaPoints;
            Debug.Log(health);
        }
        if (health <= 0)
        {
            
            if (GetComponent<BossAI>().isDead == false)
            {
                anim.SetTrigger("isDead");
                GetComponent<BossAI>().Death();
            }

           
        }
        slider.value = health;
        if (health <= 50 && !GetComponent<RandomLightning>().enabled)
        {
            GetComponent<RandomLightning>().enabled = true;
        }
    }

}
