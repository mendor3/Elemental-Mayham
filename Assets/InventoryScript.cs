using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public int existingItems = 15;
    public int maxItem = 8;
    public int maxLevel = 6;
    private int?[] inventory; //its int? because normal int cant be null
    private int itemCount = 0;
    public ItemCatalogScript itemCatalog;
    public GameObject operatorObj;
    public GameObject player; 
    public GameObject inventoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new int?[maxItem];
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
                if(itemCatalog.GetCurrLevel(newItem) == maxLevel)
                {
                    Debug.Log("achieved max level item");
                    CheckElementCombo(newItem,idx);
                    //check elementsoul
                }

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

                    InvScreenUpdate(idy,newItem);
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

    /* Randomly generates number as a reward -than checks if inventory is full if not checks if item is in inventory and is full level if not proceed if it is flags
        if inventory is full check for item in inventory that is not full level if there isnt any flags 
        in case loop is running for too long checks if invenotry isnt full of full level items by CheckIfFullLevelInventory*/
    public int RewardItem()
    {
        int loopCount = 0;
        while (true)
        {
            int item = UnityEngine.Random.Range(0,existingItems);
            //Debug.Log("ding! " + item);
            bool flag = false;
            loopCount++;

            if(itemCount >= maxItem)
            {
                flag = true;
                for(int i = 0; i < itemCount; i++)
                {
                    if(item == inventory[i] && itemCatalog.GetCurrLevel((int)inventory[i]) < maxLevel)
                    {
                        flag = false;
                    }
                }
            }else {
                for(int i = 0; i < itemCount; i++)
                {
                    if(item == inventory[i] && itemCatalog.GetCurrLevel((int)inventory[i]) == maxLevel)
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
            if (itemCatalog.GetCurrLevel((int)inventory[i]) != maxLevel)
            {
                return false;
            }
            i++;
        }
        return true;
    }


    private void CheckElementCombo(int id, int arrayId)
    {
        string type = itemCatalog.GetType(id);
        string element = itemCatalog.GetElement(id);
        string element2; 
    
        for(int i = 0; i < itemCount; i++)
        {
            element2 = itemCatalog.GetElement((int)inventory[i]);

            if(itemCatalog.GetType((int)inventory[i]) == type 
            && itemCatalog.GetCurrLevel((int)inventory[i]) == maxLevel
            && element2 != "complex"
            && (int)inventory[i] != id)
            {
                Debug.Log("Found fiting item");

                //Debug.Log("Deleting: " + "ItemOperator" + inventory[i] + "(Clone)" + " and also " + "ItemOperator" + inventory[arrayId] + "(Clone)");
                Destroy(GameObject.Find("ItemOperator" + inventory[i] + "(Clone)"));
                Destroy(GameObject.Find("ItemOperator" + inventory[arrayId] + "(Clone)"));

                inventory[i] = null;
                inventory[arrayId]= null;
                itemCount -= 2;

                InventoryUpdate(itemCatalog.GetCombo(element,element2,type));
                break;
            }
        } 

    }

    private void InvScreenUpdate(int invId, int itemId)
    {
        inventoryScreen.transform.GetChild(invId).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = itemCatalog.getSprite(itemId);
        inventoryScreen.transform.GetChild(invId).GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;
    }
}
