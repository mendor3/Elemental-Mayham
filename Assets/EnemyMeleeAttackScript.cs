using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackScript : MonoBehaviour
{
    public PlayerHpScript playerHp;
    public int demage = 5;
    private int touchTimer = 0;
    private bool touching = false;



    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("Player").GetComponent<PlayerHpScript>();
    }

    void FixedUpdate()
    {
        if(touching)
        {
            DoDemage();
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
    private void DoDemage()
    {
        touchTimer++;
        if( touchTimer == 25)
        {
            playerHp.TakeDemage(demage);
            touchTimer = 0;
        }  
    }
}
