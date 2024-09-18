using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    public Rigidbody2D myrigidbody;

    public Logic_script logic;
    public GameObject attack;


    public float player_speed;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    // Update is called 50 times per second (every 0,02 sec)
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if(horizontal == 1)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            //Vampire survivors like movement dont need 8 or 4 directions
            /*if(vertical == 1)
            {
                transform.rotation = Quaternion.Euler(0,0,45);
            }
            else if(vertical == 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }else 
            {
                transform.rotation = Quaternion.Euler(0,0,315);
            }
        }else if(horizontal == 0){
            if(vertical == 1)
            {
                transform.rotation = Quaternion.Euler(0,0,90);
            }
            else if(vertical == 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }else 
            {
                transform.rotation = Quaternion.Euler(0,0,270);
            }*/
        }else {
            transform.rotation = Quaternion.Euler(0,0,180);
            /*
            if(vertical == 1)
            {
                transform.rotation = Quaternion.Euler(0,0,135);
            }
            else if(vertical == 0)
            {
                transform.rotation = Quaternion.Euler(0,0,180);
            }else 
            {
                transform.rotation = Quaternion.Euler(0,0,225);
            }*/
        }
        
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        myrigidbody.velocity = new Vector2(horizontal * player_speed, vertical * player_speed);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

}
