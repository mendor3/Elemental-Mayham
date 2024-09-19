using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class EnemyHpScript : MonoBehaviour
{
    public PlayerLevelScript playerLevel;
    public float hp = 10;
    public int xp = 2;

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
    }

    public void TakeDemage(float demage)
    {
        hp = hp - demage;
    }
}
