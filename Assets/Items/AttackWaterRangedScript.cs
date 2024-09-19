using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackWaterRangedScript : MonoBehaviour
{
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;

    private int id = 6;
    private float demage;
    private float duration;
    public float offsetX = 0;
    public float offsetY = 0;
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
        realDemage = demage;
        realDuration = duration * 50;
    }

    void FixedUpdate()
    {
        float xVec,yVec;
    
        xVec = player.transform.position.x + offsetX;
        yVec = player.transform.position.y + offsetY;


        this.transform.position = new Vector3(xVec,yVec,player.transform.position.z);
        gameObject.GetComponent<Renderer>().enabled = true;
        timer++;
        if(timer >= (int)realDuration)
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

    public void SetOffset(int[] offset)
    {
        this.offsetX = offset[0];
        this.offsetY = offset[1];
    }
}