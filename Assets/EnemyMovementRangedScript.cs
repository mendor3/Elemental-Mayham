using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRangedScript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D myRGBody;
    public float speed = 1f;
    public float minDistance = 5f;
    private float distance;
    [SerializeField] private bool stunned = false;
    [SerializeField] private bool slowed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer(speed);
    }


    private void MoveToPlayer(float moveSpeed)
    {
        if(!stunned)
        {
            if(slowed)
            {
                moveSpeed = moveSpeed - (moveSpeed / 2); //50% movespeed
            }

            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector3 direction = (player.transform.position - transform.position).normalized;

            if(distance > minDistance)
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
}
