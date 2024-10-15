using System.Collections;
using System.Collections.Generic;

//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy_script : MonoBehaviour
{
    /* PUBLIC */
    public GameObject player;
    public PlayerHpScript playerHp;
    public Rigidbody2D myRGBody;

/* PUBLIC VARIABLES FOR GAME SETTINGS*/
    public float speed = 1f;
    public int demage = 5;

    public float minDistance = 1.8f;


/*  PRIVATE */
    //private float moveLimiter = 0.7f;
    private int touchTimer = 0;
    private bool touching = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerHp = GameObject.Find("Player").GetComponent<PlayerHpScript>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveToPlayer(speed);
        


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

    private void MoveToPlayer(float moveSpeed)
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        if(!touching)
        {
            myRGBody.MovePosition(myRGBody.transform.position + direction * moveSpeed * Time.fixedDeltaTime);
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        if(angle >= -90 && angle <= 90) //prava
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }else {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

}
