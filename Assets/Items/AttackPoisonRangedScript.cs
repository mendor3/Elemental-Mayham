using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoisonRangedScript : MonoBehaviour
{
    public Rigidbody2D myRGBody;

    
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;


    private int id = 9;
    private float demage;
    private float duration;
    private int level;
    private float realDuration;
    private float timer = 0;
    public bool right;
    [SerializeField] private float poisonChance = 10;
    
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
        float xVec;

        if(right)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            xVec = transform.position.x + 0.2f;
        }else {
            xVec = transform.position.x - 0.2f;
        }

        transform.position = new Vector3(xVec,transform.position.y, transform.position.z);

        timer++;
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
            Destroy(gameObject);
        }
    }
}
