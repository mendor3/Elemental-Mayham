using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAirRangedScript : MonoBehaviour
{
    public Rigidbody2D myRGBody;

    
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;


    private int id = 8;
    private float demage;
    private float duration;
    private int level;
    private float realDemage;
    private float realDuration;
    private float timer = 0;
    private bool first = true;
    private bool right = true;

    void Start()
    {
        itemCatalog = GameObject.FindGameObjectWithTag("Logic").GetComponent<ItemCatalogScript>();
        player = GameObject.Find("Player");
        level = itemCatalog.GetCurrLevel(id);
        demage = itemCatalog.getDemage(id, level);
        duration = itemCatalog.GetDuration(id,level);
        realDemage = demage;
        realDuration = duration * 50;
    }

    void FixedUpdate()
    {
        float xVec;
        if(first)
        {
            if(player.transform.rotation.eulerAngles.z == 0)
            {
                right =  true;
                first = false;
            }else {
                transform.rotation = Quaternion.Euler(0,0,180);
                right = false;
                first = false;
            }
        }

        if(right)
        {
            xVec = transform.position.x + 0.2f;
        }else {
            xVec = transform.position.x - 0.2f;
        }

        transform.position = new Vector3(xVec,transform.position.y, transform.position.z);

        timer++;
        if(timer == (int)realDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Enemy" )
        {
            target = collision.gameObject;
            target.GetComponent<EnemyHpScript>().TakeDemage(realDemage);
            Destroy(gameObject);
        }
    }
}
