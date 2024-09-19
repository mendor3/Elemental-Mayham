using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAirMeleeScript : MonoBehaviour
{
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;

    private int id = 3;
    private float demage;
    private float duration;
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
        realDuration = duration * 50;
    }
    
    void FixedUpdate()
    {
        float xVec,yVec;
        xVec = player.transform.position.x;
        yVec = player.transform.position.y - ( playerRenderer.bounds.size.y / 2) - (myRenderer.bounds.size.y / 2);
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

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
