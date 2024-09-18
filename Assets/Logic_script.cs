using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System;
using JetBrains.Annotations;
using UnityEditor.SceneManagement;
using UnityEngine.AI;

public class Logic_script : MonoBehaviour
{
    public int hp = 100;
    public float spawnOffset = 5f;
    public int level = 1;
    public int xp = 0;
    public int maxItem = 6;



    public TMP_Text timeCount;
    public TMP_Text healt;
    public TMP_Text levelText;
    public TMP_Text xpText;
    public GameObject player; 
    public GameObject enemy;
    public LevelUpScreenScript levelUpScreen;
    public GameObject operatorObj;
    public GameOverScreen_script gameOverScreen;
    public ItemCatalogScript itemCatalog;
    public EnemyCatalogScript enemyCatalog;
    public Slider healthBar;
    public Camera myCamera;
    public Slider xpBar;

    public Renderer playerRenderer;


    private int stage = 0;
    private float gameTime = 0;
    private float spawnTime = 0;
    private int itemCount = 0;

    private int xpMax = 10;
    private int?[] inventory; 
    private GameObject[] invObj;
    private List<int[]> stageList;
    private List<GameObject> enemyList;

    private int spawnCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        stageList = new List<int[]>();
        enemyList = new List<GameObject>();

        StageChanger(stage);
        xpBar.maxValue = xpMax;
        xpBar.value = xp;

        inventory = new int?[maxItem];
    }
    // FixedUpdate is called every 0.2 seconds or 50x per second
    private void FixedUpdate()
    {
        TimeDisplay();

        spawnCounter++;
        if(spawnCounter == 50)
        {
            StageManager();
            SpawnManager();
            spawnCounter = 0;
        }
    }

    //takes game time adds elapsed time to it (0.02 sec used because fixedupdate) and formates it into text that is displayed on screen
    private void TimeDisplay()
    {
        gameTime += 0.02f;
        float minutes = Mathf.FloorToInt(gameTime/ 60); 
        float seconds = Mathf.FloorToInt(gameTime % 60);
        timeCount.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }

    // Every 2 minutes increases stage number and calls StageChange()
    private void StageManager()
    {
        float minutes = Mathf.FloorToInt(gameTime/ 60); 

        if( (int)minutes / 2 > stage)
        {
            stage++;
            StageChanger(stage);
        }
    }

    //Updates list of enemies and their spawn frequencies also reset the spawnTime for next stage
    private void StageChanger(int stage)
    {
        spawnTime = 0;
        int[] enemySet = new int[3];

        switch (stage)
        {
            case 0: 
                stageList.Clear();
                enemyList.Clear();

                enemyList.Add(enemyCatalog.GetEnemy(0));

                enemySet[0] = 0;
                enemySet[1] = 0;
                enemySet[2] = 2;
                stageList.Add(enemySet);
            break;

            case 1:
                stageList.Clear();
                enemyList.Clear();

                enemyList.Add(enemyCatalog.GetEnemy(0));
                enemyList.Add(enemyCatalog.GetEnemy(1));

                enemySet[0] = 0;
                enemySet[1] = 0;
                enemySet[2] = 2;
                stageList.Add(enemySet);

                enemySet[0] = 1;
                enemySet[1] = 0;
                enemySet[2] = 5;
                stageList.Add(enemySet);
            break;




            default: 
                stageList.Clear();
                enemyList.Clear();

                enemyList.Add(enemyCatalog.GetEnemy(0));

                enemySet[0] = 0;
                enemySet[1] = 0;
                enemySet[2] = 2;
                stageList.Add(enemySet);
            break;
        }
    }

    //Reduces player hp but also checks if hp is 0 calls GameOver() also displayed new hp after reduction (reduction can be 0)
    public void TakeDemage(int demage)
    {
        hp = hp - demage;
        healthBar.value = hp;
        healt.text = hp.ToString();
        
        if( hp == 0)
        {
            GameOver();
        }
    }

    // Stops game time and shows gameover screen
    private void GameOver() 
    {
        Time.timeScale = 0;
        gameOverScreen.Setup(timeCount.text);
    }

    //Checks if enough time elapse to spawn enemy and than increases next time by frequency
    private void SpawnManager()
    {
        spawnTime++;
        for(int i = 0; i < stageList.Count; i++)
        {
            if(stageList[i][1] <= spawnTime)
            {
                SpawnEnemy(enemyList[i]);
                stageList[i][1] = stageList[i][1] + stageList[i][2];
            }
        }
    }

    //Spawns enemy that was given to it in random direction outside of the camera view
    private void SpawnEnemy(GameObject enemy)
    {
        float height = myCamera.orthographicSize + spawnOffset;
        float width = myCamera.orthographicSize * myCamera.aspect + spawnOffset;

        float sides = UnityEngine.Random.Range(1,4);

        switch(sides)
        {
            case 1:
                Instantiate(enemy, new Vector3(myCamera.transform.position.x + width,UnityEngine.Random.Range(-height, height),1), Quaternion.identity);
            break;
            case 2:
                Instantiate(enemy, new Vector3(myCamera.transform.position.x - width,UnityEngine.Random.Range(-height, height),1), Quaternion.identity);
            break;
            case 3:
                Instantiate(enemy, new Vector3(UnityEngine.Random.Range(-width, width),myCamera.transform.position.y - height,1), Quaternion.identity);
            break;
            case 4:
                Instantiate(enemy, new Vector3(UnityEngine.Random.Range(-width, width),myCamera.transform.position.y + height,1), Quaternion.identity);
            break;
        }
    }

    // adds xp and calls LevelManager()
    public void AddXP(int newXp)
    {
        xp = xp + newXp;
        LevelManager();
    }

    // checks if xp is enough to level up if so adds level, increases xp cap, returns xp to 0, writes new xp and level on player screen and shows reward screen
    private void LevelManager()
    {
        if(xp >= xpMax)
        {
            level++;
            xpMax = xpMax + 10;
            xp = 0;
            xpBar.maxValue = xpMax;
            levelText.text = level.ToString();
            levelUpScreen.Setup(RewardItem(),RewardItem(),RewardItem());
        }
        xpBar.value = xp;
        xpText.text = xp.ToString();
    }

    /* Adds new item into inventory, checks if item is already in invetory and if it is levels it up if it isnt 
    it adds item into new inventory slot, creates item operator and increases item count*/
    public void InventoryUpdate(int newItem)
    {
        bool lvld = false;

        for( int idx = 0; idx < itemCount;idx++)
        {   
            if(newItem == inventory[idx])
            {
                itemCatalog.LevelUp(newItem);
                lvld = true;
                break;
            }
        }

        if(lvld == false)
        {
            for( int idy = 0; idy < maxItem;idy++)
            {
                if(inventory[idy] == null)
                {
                    inventory[idy] = newItem;
                    GameObject itemN = operatorObj;
                    itemN.GetComponent<ItemOperatorScript>().Setup(newItem,1);
                    itemN.name = "ItemOperator" + newItem;
                    Instantiate( itemN, player.transform.position, Quaternion.identity);
                    itemCount++;
                    break;
                }   
            }
        }

    }

    //Gives player starting item with InventoryUpdate
    public void StartingItem(int id)
    {
        InventoryUpdate(id);
    }

    /* Randomly generates number as a reward -than checks if inventory is full if not checks if item is in inventory and is full level if not proceed if it is flags
        if inventory is full check for item in inventory that is not full level if there isnt any flags 
        in case loop is running for too long checks if invenotry isnt full of full level items by CheckIfFullLevelInventory*/
    private int RewardItem()
    {
        int loopCount = 0;
        while (true)
        {
            int item = UnityEngine.Random.Range(0,10);
            bool flag = false;
            loopCount++;

            if(itemCount >= maxItem)
            {
                flag = true;
                for(int i = 0; i < itemCount; i++)
                {
                    if(item == inventory[i] && itemCatalog.GetCurrLevel((int)inventory[i]) < 6)
                    {
                        flag = false;
                    }
                }
            }else {
                for(int i = 0; i < itemCount; i++)
                {
                    if(item == inventory[i] && itemCatalog.GetCurrLevel((int)inventory[i]) == 6)
                    {
                        flag = true;
                    }
                }
            }

            if(!flag)
            {
                return item;
            }

            if(loopCount > 20)
            {
                if (CheckIfFullLevelInvetory())
                {
                    //TODO co se stane kdyz full level invetar
                }
            }
        }
    }
    
    //Chechks if all items in inventory are full level if so returns true otherwise returns false
    private bool CheckIfFullLevelInvetory()
    {
        int i = 0;
        while(i <= itemCount)
        {
            if (itemCatalog.GetCurrLevel((int)inventory[i]) != 6)
            {
                return false;
            }
            i++;
        }
        return true;
    }
    
}
