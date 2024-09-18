using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class EnemyHpScript : MonoBehaviour
{
    public Logic_script logic;
    public float hp = 10;
    public int xp = 2;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
    }


    void FixedUpdate()
    {
        if(hp < 0.1)
        {
            logic.AddXP(xp);
            Destroy(this.gameObject);
        }
    }

    public void TakeDemage(float demage)
    {
        hp = hp - demage;
    }
}
