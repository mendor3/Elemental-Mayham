using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackScript : MonoBehaviour
{
    public PlayerHpScript playerHp;
    public int damage = 5;
    private int touchTimer = 0;
    private bool touching = false;

    [SerializeField] private bool weakness = false;



    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("Player").GetComponent<PlayerHpScript>();
    }

    void FixedUpdate()
    {
        if(touching)
        {
            DoDemage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player" )
        {
            touching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player" )
        {
            touching = false;
        }
    }


    //MY FUNCTIONS
    private void DoDemage(int realDmg)
    {
        if(weakness)
        {
            realDmg = (int)Math.Floor((double)realDmg - (realDmg / 2));//50% of damage
        }

        touchTimer++;
        if( touchTimer == 25)
        {
            playerHp.TakeDemage(realDmg);
            touchTimer = 0;
        }  
    }
}
