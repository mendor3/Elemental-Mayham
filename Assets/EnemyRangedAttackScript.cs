using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyRangedAttackScript : MonoBehaviour
{
    public GameObject bullet;
    public Animator animator;
    public float attackCooldown = 1;
    public float range = 10f;
    public float demage = 1;


    private GameObject player;
    private float realAttackCooldown;
    private int timer = 0;
    private bool loaded = false;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        realAttackCooldown = attackCooldown * 50;
    }


    void FixedUpdate()
    {
        timer++;
        
        if(timer >= realAttackCooldown && !loaded)
        {
            loaded = true;
        }

        if(loaded)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Debug.Log("In range? " + distance + " <= " + range);

            if(distance <= range)
            {
                Shoot();
                loaded = false;
                timer = 0;
            }
        }
    }

    private void Shoot()
    {
        animator.SetTrigger("Shoot");
        bullet.GetComponent<EnemyBulletScript>().demage = demage;
        Instantiate( bullet, transform.position, Quaternion.identity);
    }
}
