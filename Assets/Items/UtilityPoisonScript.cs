using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityPoisonScript : MonoBehaviour
{
   private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;

    private int id = 14;
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
    }
    
    void FixedUpdate()
    {
        float xVec;
        xVec = player.transform.position.x + ( playerRenderer.bounds.size.x / 2) - (myRenderer.bounds.size.x / 4);
        this.transform.position = new Vector3(xVec,player.transform.position.y,player.transform.position.z);
        gameObject.GetComponent<Renderer>().enabled = true;
        timer++;

        PoisonCoating();

        if(timer >= (int)realDuration)
        {
            Destroy(gameObject);
        }
    }

    private void PoisonCoating()
    {
        //TODO poison damage
    }
}
