using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireMeleeScript : MonoBehaviour
{
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;

    private int id = 0;
    private float demage;
    private float duration;
    private int level;
    private float realDemage;
    private float realDuration;
    private float timer = 0;

    private bool poisonEffect = false;
    private float poisonChance = 0;

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
        poisonEffect = itemCatalog.poisonEffect;
        if(poisonEffect)
        {
            poisonChance = itemCatalog.GetPoisonPassive();
        }
    }
    
    void FixedUpdate()
    {
        float xVec;
        if(player.transform.rotation.eulerAngles.y == 0)
        {
            xVec = player.transform.position.x + ( playerRenderer.bounds.size.x / 2) + (myRenderer.bounds.size.x / 2);
            transform.rotation = Quaternion.Euler(0,0,0);
        }else {
            xVec = player.transform.position.x - ( playerRenderer.bounds.size.x / 2) - (myRenderer.bounds.size.x / 2);
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        this.transform.position = new Vector3(xVec,player.transform.position.y,player.transform.position.z);
        gameObject.GetComponent<Renderer>().enabled = true;

        timer++;

        if(timer >= (int)realDuration)
        {
            Destroy(gameObject);
        }
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Enemy" )
        {
            target = collision.gameObject;
            target.GetComponent<EnemyHpScript>().TakeDemage(realDemage);
            if(poisonEffect)
            {
                target.GetComponent<EnemyHpScript>().DoPoison(poisonChance);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
