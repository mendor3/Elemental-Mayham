using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public int maxItem = 6;
    private int?[] inventory; 
    private int itemCount = 0;
    public ItemCatalogScript itemCatalog;
    public GameObject operatorObj;
    public GameObject player; 

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

    /* Randomly generates number as a reward -than checks if inventory is full if not checks if item is in inventory and is full level if not proceed if it is flags
        if inventory is full check for item in inventory that is not full level if there isnt any flags 
        in case loop is running for too long checks if invenotry isnt full of full level items by CheckIfFullLevelInventory*/
    public int RewardItem()
    {
        int loopCount = 0;
        while (true)
        {
            int item = UnityEngine.Random.Range(0,11);
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
