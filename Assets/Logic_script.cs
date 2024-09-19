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
    public InventoryScript inventory;

    public float spawnOffset = 5f;


    private int stage = 0;
    private float gameTime = 0;
    private float spawnTime = 0;
    private List<int[]> stageList;
    private List<GameObject> enemyList;
    private int spawnCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        stageList = new List<int[]>();
        enemyList = new List<GameObject>();

        StageChanger(stage);
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

    //Gives player starting item with InventoryUpdate
    public void StartingItem(int id)
    {
        inventory.InventoryUpdate(id);
    }
    
    // Stops game time and shows gameover screen
    public void GameOver() 
    {
        Time.timeScale = 0;
        gameOverScreen.Setup(timeCount.text);
    }

    //Updates text and healtbar with next hp
    public void UpdateHp(int hp)
    {
        healthBar.value = hp;
        healt.text = hp.ToString();
    }

    // adds xp and calls LevelManager()
    public void XpUpdate(int xp)
    {
        xpBar.value = xp;
        xpText.text = xp.ToString();
    }

    // checks if xp is enough to level up if so adds level, increases xp cap, returns xp to 0, writes new xp and level on player screen and shows reward screen
    public void LevelUpdate(int level, int xpMax)
    {
        xpBar.maxValue = xpMax;
        levelText.text = level.ToString();
        levelUpScreen.Setup(inventory.RewardItem(),inventory.RewardItem(),inventory.RewardItem());
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
    
}
