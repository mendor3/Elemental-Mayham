using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackPoisonMeleeScript : MonoBehaviour
{
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;

    private int id = 4;
    private float demage;
    private float duration;
    public float count;
    private int level;
    private float realDuration;
    private float timer = 0;
    [SerializeField] private float poisonChance = 10;
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
        realDuration =  duration * 50 / 3;
    }
    
    void FixedUpdate()
    {
        float xVec,yVec;
        switch (count)
        {
            case 1: 
                xVec = player.transform.position.x - ( playerRenderer.bounds.size.x / 2);
                break;
            case 2:
                xVec = player.transform.position.x;
                break;
            case 3:
                xVec = player.transform.position.x + ( playerRenderer.bounds.size.x / 2);
                break;
            default:
                xVec = player.transform.position.x;
                break;
        }
        
        yVec = player.transform.position.y + ( playerRenderer.bounds.size.y / 2) + (myRenderer.bounds.size.y / 2);

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
            target.GetComponent<EnemyHpScript>().DoPoison(poisonChance);
        }
    }
    
    public void SetCount(int count)
    {
        this.count = count;
    }
}
