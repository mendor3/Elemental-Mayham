using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public Rigidbody2D myRGBody;
    private GameObject player;

    private Vector3 targetLoc;
    private Vector3 direction;
    public float duration = 5;
    private float realDuration;
    public float demage = 1;
    private float realDemage;

    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        targetLoc = player.transform.position;
        realDemage = demage;
        realDuration = duration * 50;
        direction = (targetLoc - transform.position).normalized;
    }

    void FixedUpdate()
    {
        //Vector3 direction = (targetLoc - transform.position).normalized;

        myRGBody.MovePosition(myRGBody.transform.position + direction * 16 * Time.fixedDeltaTime);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);


        timer++;
        if(timer == (int)realDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player" )
        {
            player.GetComponent<PlayerHpScript>().TakeDemage((int)realDemage);
            /*if(poisonEffect)
            {
                target.GetComponent<EnemyHpScript>().DoPoison(poisonChance);
            }*/
            Destroy(gameObject);
        }

        if( collision. gameObject.name == "UtilityEarth(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
