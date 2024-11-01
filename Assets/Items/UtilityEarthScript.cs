using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityEarthScript : MonoBehaviour
{
    private ItemCatalogScript itemCatalog;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;

    private int id = 12;
    private int level;
    private float demage;
    private float duration;
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
        realDuration = duration * 50;
    }
    
    void FixedUpdate()
    {
        float xVec;
        xVec = player.transform.position.x + ( playerRenderer.bounds.size.x / 2) + (myRenderer.bounds.size.x / 4);
        this.transform.position = new Vector3(xVec,player.transform.position.y,player.transform.position.z);

        gameObject.GetComponent<Renderer>().enabled = true;
        timer++;

        if(timer >= (int)realDuration)
        {
            Destroy(gameObject);
        }
    }



}
