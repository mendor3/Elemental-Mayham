using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAirScript : MonoBehaviour
{
   private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;

    private int id = 13;
    private int level;
    private float demage;
    private float duration;
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
        Speed();
    }
    
    void FixedUpdate()
    {
        float yVec;
        yVec = player.transform.position.y - ( playerRenderer.bounds.size.y / 2) + (myRenderer.bounds.size.y / 4);
        this.transform.position = new Vector3(player.transform.position.x,yVec,player.transform.position.z);
        gameObject.GetComponent<Renderer>().enabled = true;
        timer++;


        if(timer >= (int)realDuration)
        {
            Destroy(gameObject);
        }
    }

    private void Speed()
    {
        player.GetComponent<PlayerMovementScript>().player_speed = demage;
    }
}
