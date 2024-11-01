using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedExplosionScript : MonoBehaviour
{
    public Rigidbody2D myRGBody;

    
    private ItemCatalogScript itemCatalog;
    private GameObject target;
    private GameObject player;
    private Renderer playerRenderer;
    private Renderer myRenderer;
    private Vector3 targetLoc;


    private int id = 28;
    private float demage;
    private float duration;
    private int level;
    private float realDuration;
    private float timer = 0;
    private bool poisonEffect = false;
    private float poisonChance = 0;
    private bool exploded = false;
    [SerializeField] private float speed = 10;
    [SerializeField] Sprite explosion;


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

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<Transform> enemy_loc = new List<Transform>();

        foreach(GameObject tran in enemies)
        {
            enemy_loc.Add(tran.transform);
        }

        targetLoc = GetClosestEnemy(enemy_loc).position;
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetLoc - transform.position).normalized;

        if(!exploded)
        {
            myRGBody.MovePosition(myRGBody.transform.position + direction * speed * Time.fixedDeltaTime);
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);


        timer++;
        if(timer >= (int)realDuration)
        {
            Explode();
        }
        if(timer >= 25 && exploded)
        {
            Destroy(gameObject);
        }
    }

    Transform GetClosestEnemy (List<Transform> enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = player.transform.position;
        foreach(Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
     
        return bestTarget;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Enemy" )
        {
            if(!exploded)
            {
                target = collision.gameObject;
                target.GetComponent<EnemyHpScript>().TakeDemage(demage * 2);
                if(poisonEffect)
                {
                    target.GetComponent<EnemyHpScript>().DoPoison(poisonChance);
                }
                Explode();
            }else{
                target = collision.gameObject;
                target.GetComponent<EnemyHpScript>().TakeDemage(demage);
                if(poisonEffect)
                {
                    target.GetComponent<EnemyHpScript>().DoPoison(poisonChance);
                }
            }
        }
    }

    private void Explode()
    {
        Color myColor;
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion;
        gameObject.transform.localScale = new Vector3(3,3,3);
        myColor = gameObject.GetComponent<SpriteRenderer>().color;
        myColor.a = 0.7f;
        gameObject.GetComponent<SpriteRenderer>().color = myColor;      
        gameObject.GetComponent<CircleCollider2D>().radius = 0.55f;
        exploded = true;
        timer = 0;
    }
}
