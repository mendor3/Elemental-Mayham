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
    public GameObject damagePopup;

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
        if(demage != 0)
        {
            ShowDemage(demage);
        }
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
    
}
