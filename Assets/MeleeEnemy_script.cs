using System.Collections;
using System.Collections.Generic;

//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy_script : MonoBehaviour
{
    /* PUBLIC */
    public GameObject player;
    public Logic_script logic;
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
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
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
            logic.TakeDemage(demage);
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
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

}
