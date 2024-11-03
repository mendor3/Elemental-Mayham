using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using TMPro;
using UnityEngine;

public class EnemyHpScript : MonoBehaviour
{
    public PlayerLevelScript playerLevel;
    public float hp = 10;
    public int xp = 2;
    public float armor = 1;
    public GameObject damagePopup;

    private int timer = 0;
    private int poisonTimer = 10;
    private int fireTimer = 3;
    [SerializeField] private bool poisoned = false;
    [SerializeField] private bool vulnerable = false;
    [SerializeField] private bool onFire = false;
    [SerializeField] private bool irradiated = false;

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
            TakePoisonDamage(1);
            TakeFireDamage(5);
            TakeRadiationDamage(1);
        }
    }

    public void TakeDemage(float damage)
    {
        float realDmg;
        if(damage == 1)
        {
            realDmg = 1;
        }else{
            realDmg = (int)Math.Floor(damage - (damage * (armor / 100)));
        }

        if(vulnerable)
        {
            realDmg = realDmg + (damage / 2); //50% from damage unaffected by armor
        }

        hp = hp - realDmg;
        if(realDmg != 0)
        {
            ShowDemage(realDmg);
        }
    }

    public void OtherDamage(float dmg)
    {
        hp = hp - dmg;
        ShowDemage(dmg);
    }

    private void TakePoisonDamage(float posionDmg)
    {
        if(poisoned)
        {
            poisonTimer--;
            if(poisonTimer > 0)
            {
                OtherDamage(posionDmg);
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
        Debug.Log("Poison yes");
    }

    public void DoPoison(float chance)
    {
        Debug.Log("poison maybe?");
        float percentage = UnityEngine.Random.Range(0,101);
        if(percentage <= chance)
        {
            Poisoned();
        }
    }

    public void ShowDemage(float damage)
    {
        damagePopup.transform.GetChild(0).GetComponent<TMP_Text>().text = damage.ToString();
        Instantiate(damagePopup,gameObject.transform.position, Quaternion.identity);
    }

    public void TakeFireDamage(float fireDmg)
    {
        if(onFire)
        {
            fireTimer--;
            if(fireTimer > 0)
            {
                OtherDamage(fireDmg);
            }else{
                onFire = false;
                fireTimer = 10;
            }
        }
    }

    public void TakeRadiationDamage(float radDmg)
    {
        if(irradiated)
        {
            OtherDamage(radDmg);
        }
    }
    
}
