using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackWaterMeleeScript : MonoBehaviour
{
    public float count;

    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;


    private int id = 1;
    private float demage;
    private float duration;
    private int level;
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
        realDuration = duration * 50;
        poisonEffect = itemCatalog.poisonEffect;
        if(poisonEffect)
        {
            poisonChance = itemCatalog.GetPoisonPassive();
        }
    }
    
    void FixedUpdate()
    {
        float xVec,yVec;

        switch (count)
        {
            case 1: 
                transform.rotation = Quaternion.Euler(0,0,0);
                xVec = player.transform.position.x + ( playerRenderer.bounds.size.x / 2) + (myRenderer.bounds.size.x / 2);
                yVec = player.transform.position.y;
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0,0,45);
                xVec = player.transform.position.x + ( playerRenderer.bounds.size.x / 2) + (myRenderer.bounds.size.x / 4);
                yVec = player.transform.position.y +  playerRenderer.bounds.size.y + (myRenderer.bounds.size.y / 8);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0,0,90);
                xVec = player.transform.position.x;
                yVec = player.transform.position.y + ( playerRenderer.bounds.size.y / 2) + (myRenderer.bounds.size.y / 2);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0,0,135);
                xVec = player.transform.position.x - ( playerRenderer.bounds.size.x / 2) - (myRenderer.bounds.size.x / 4);
                yVec = player.transform.position.y + playerRenderer.bounds.size.y + (myRenderer.bounds.size.y / 8);
                break;
            case 5:
                transform.rotation = Quaternion.Euler(0,0,180);
                xVec = player.transform.position.x - ( playerRenderer.bounds.size.x / 2) - (myRenderer.bounds.size.x / 2);
                yVec = player.transform.position.y;
                break;
            case 6:
                transform.rotation = Quaternion.Euler(0,0,225);
                xVec = player.transform.position.x - ( playerRenderer.bounds.size.x / 2) - (myRenderer.bounds.size.x / 4);
                yVec = player.transform.position.y - playerRenderer.bounds.size.y - (myRenderer.bounds.size.y / 8);
                break;
            case 7:
                transform.rotation = Quaternion.Euler(0,0,270);
                xVec = player.transform.position.x;
                yVec = player.transform.position.y - ( playerRenderer.bounds.size.y / 2) - (myRenderer.bounds.size.y / 2);
                break;
            case 8:
                transform.rotation = Quaternion.Euler(0,0,315);
                xVec = player.transform.position.x + ( playerRenderer.bounds.size.x / 2) + (myRenderer.bounds.size.x / 4);
                yVec = player.transform.position.y - playerRenderer.bounds.size.y - (myRenderer.bounds.size.y / 8);
                break;
            default:
                transform.rotation = Quaternion.Euler(0,0,0);
                xVec = player.transform.position.x + ( playerRenderer.bounds.size.x / 2) + (myRenderer.bounds.size.x / 2);
                yVec = player.transform.position.y;
                break;
        }

        this.transform.position = new Vector3(xVec,yVec,player.transform.position.z);
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

    public void SetCount(int count)
    {
        this.count = count;
    }
}
