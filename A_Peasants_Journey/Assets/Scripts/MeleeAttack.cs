using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    //Variables

    Animator anim;
    public float StartDamage = 20f;
    private float Damage;
    public float StartDelay = .3f;      //Stops bug where accidental double hit can happen
    private float Delay;
    private Drone alert;
    public float SneakDamageMultiplier = 1.5f;
    void Start()
    {
        Damage = StartDamage;
        anim = GetComponent<Animator>();
        Delay = StartDelay;
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attacking", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Attacking", false);
        }

        if (Delay > -.1)
        {
            Delay -= Time.deltaTime;        //Timer runs and is stopped at -.1
        }
    }

    private void OnTriggerEnter(Collider other)         //Doing Damage
    {
       
        if (other.tag == "Enemy")
        {
            if (Delay <= 0)
            {
                alert = other.GetComponent<Drone>();
                if (alert.isAware == false)
                {
                    Damage *= SneakDamageMultiplier;
                }
                HealthManager.PlayersDamage = Damage;
                Damage = StartDamage;
                Delay = StartDelay;        //Resets Timer
            }
        }
    }
}
