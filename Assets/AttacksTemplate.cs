using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacksTemplate : MonoBehaviour
{
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;

    private int id = 100000;
    private float damage;
    private float duration;
    private int level;
    private float realDuration;
    private float timer = 0;
    private bool poisonEffect = false;
    private float poisonChance = 0;
    private int critChance = 0;
    private int critDamage = 0;
    private int critModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        itemCatalog = GameObject.FindGameObjectWithTag("Logic").GetComponent<ItemCatalogScript>();
        player = GameObject.Find("Player");
        playerRenderer = player.GetComponent<Renderer>();
        myRenderer = gameObject.GetComponent<Renderer>();
        level = itemCatalog.GetCurrLevel(id);
        damage = itemCatalog.getDemage(id, level);
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
        BasicMeleePositioning();

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
            float percentage = UnityEngine.Random.Range(0,101); //Crit chance
            if(percentage <= critChance)
            {
                critDamage = (int)damage * critModifier;
            }

            target = collision.gameObject;
            target.GetComponent<EnemyHpScript>().TakeDemage(damage + critChance);

            if(poisonEffect) //poison chance
            {
                target.GetComponent<EnemyHpScript>().DoPoison(poisonChance);
            }
            critDamage = 0;
        }
    }

    private void BasicMeleePositioning() //Basic Melee follow player and direction 
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
    }
}
