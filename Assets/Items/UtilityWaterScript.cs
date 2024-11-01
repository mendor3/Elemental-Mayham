using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityWaterScript : MonoBehaviour
{
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;


    private int id = 11;
    private int level;
    private float demage;
    private float duration;
    private float realDuration;
    private float timer = 0;
    private float healTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        itemCatalog = GameObject.FindGameObjectWithTag("Logic").GetComponent<ItemCatalogScript>();
        player = GameObject.Find("Player");
        level = itemCatalog.GetCurrLevel(id);
        demage = itemCatalog.getDemage(id, level);
        duration = itemCatalog.GetDuration(id,level);
        realDuration = duration * 50;
    }
    
    void FixedUpdate()
    {
        this.transform.position = player.transform.position;
        gameObject.GetComponent<Renderer>().enabled = true;
        timer++;

        healTimer++;
        if(healTimer >= 50)
        {
            Heal();
            healTimer = 0;
        }

        if(timer >= (int)realDuration)
        {
            Destroy(gameObject);
        }
    }

    private void Heal()
    {
        player.GetComponent<PlayerHpScript>().TakeDemage(-(int)demage);
    }
}
