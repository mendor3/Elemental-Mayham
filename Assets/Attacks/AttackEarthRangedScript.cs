using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class AttackEarthRangedScript : MonoBehaviour
{
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;

    private int id = 7;
    private float demage;
    private float duration;
    public float count;
    private int level;
    private float realDemage;
    private float realDuration;
    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        itemCatalog = GameObject.FindGameObjectWithTag("Logic").GetComponent<ItemCatalogScript>();
        player = GameObject.Find("Player");
        playerRenderer = player.GetComponent<Renderer>();
        myRenderer = gameObject.GetComponent<Renderer>();
        level = itemCatalog.GetCurrLevel(id);
        demage = itemCatalog.getDemage(id, level);
        duration = itemCatalog.GetDuration(id,level);
        realDemage = demage / 50;
        realDuration =  duration * 50 / 3;

        float xScale,yScale;
        switch (count)
        {
            case 1: 
                xScale = transform.localScale.x;
                yScale = transform.localScale.y;
                break;
            case 2:
                xScale = transform.localScale.x + 1;
                yScale = transform.localScale.y + 1;
                break;
            case 3:
                xScale = transform.localScale.x + 2;
                yScale = transform.localScale.y + 2;
                break;
            default:
                xScale = transform.localScale.x;
                yScale = transform.localScale.y;
                break;
        }
        transform.localScale = new Vector3(xScale,yScale,transform.localScale.z);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        float xVec,yVec;

        xVec = player.transform.position.x;
        yVec = player.transform.position.y;

        this.transform.position = new Vector3(xVec,yVec,player.transform.position.z);
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
        }
    }

    public void SetCount(int count)
    {
        this.count = count;
    }
}
