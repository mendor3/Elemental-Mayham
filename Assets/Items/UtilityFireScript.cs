using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFireScript : MonoBehaviour
{
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;


    private int id = 10;
    private int level;
    private float demage;
    private float duration;
    private float realDuration;
    private float timer = 0;
    private bool poisonEffect = false;
    private float poisonChance = 0;

    // Start is called before the first frame update
    void Start()
    {
        itemCatalog = GameObject.FindGameObjectWithTag("Logic").GetComponent<ItemCatalogScript>();
        player = GameObject.Find("Player");
        level = itemCatalog.GetCurrLevel(id);
        demage = itemCatalog.getDemage(id, level);
        duration = itemCatalog.GetDuration(id,level);
        realDuration = duration * 50;
        poisonEffect = itemCatalog.poisonEffect;
        if(poisonEffect)
        {
            poisonChance = itemCatalog.GetPoisonPassive();
        }
    }
    
    void FixedUpdate()
    {
        this.transform.position = player.transform.position;
        gameObject.GetComponent<Renderer>().enabled = true;
        
        timer++;

        if(timer % 50 == 0)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        if(timer == (int)realDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Enemy" )
        {
            target = collision.gameObject;
            target.GetComponent<EnemyHpScript>().TakeDemage(demage);
            if(poisonEffect)
            {
                target.GetComponent<EnemyHpScript>().DoPoison(poisonChance);
            }
        }
    }
}
