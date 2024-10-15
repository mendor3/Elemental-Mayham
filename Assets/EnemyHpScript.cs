using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class EnemyHpScript : MonoBehaviour
{
    public PlayerLevelScript playerLevel;
    public float hp = 10;
    public int xp = 2;

    private int timer = 0;
    private int poisonTimer = 10;
    [SerializeField] private bool poisoned = false;

    void Start()
    {
        playerLevel = GameObject.Find("Player").GetComponent<PlayerLevelScript>();
    }


    void FixedUpdate()
    {
        if(hp < 0.1)
        {
            playerLevel.AddXP(xp);
            Destroy(this.gameObject);
        }

        timer++;

        if(timer >= 50)
        {
            timer = 0;
            TakePoisonDamage();
        }
    }

    public void TakeDemage(float demage)
    {
        hp = hp - demage;
    }

    private void TakePoisonDamage()
    {
        if(poisoned)
        {
            poisonTimer--;
            if(poisonTimer > 0)
            {
                TakeDemage(1);
            }else{
                poisoned = false;
                poisonTimer = 10;
            }
        }
    }

    private void Poisoned()
    {
        poisoned = true;
        poisonTimer = 10;
    }

    public void DoPoison(float chance)
    {
        float percentage = UnityEngine.Random.Range(0,10001);
        if(percentage <= ((chance * 100) / 25))
        {
            Poisoned();
        }
    }
    
}
