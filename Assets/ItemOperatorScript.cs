using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ItemOperatorScript : MonoBehaviour
{
    public GameObject player;
    public ItemCatalogScript itemCatalog;
    public GameObject attackObj;

    public int id;
    public int level;
    public float frequency;
    public float duration;
    public float interval; 

    private bool activeAtk = false;
    private float realDuration;
    private float realFrequency;
    private int timer = 0;
    private int countMax;
    private int count = 1;
    private bool right = true;


    // Start is called before the first frame update
    void Start()
    {
        realFrequency = frequency * 50;
        switch (id)
        {   case 0: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;
            case 1: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    countMax = 8;
                    interval = realDuration / countMax;
                    break;
            case 2: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50; 
                    break;
            case 3: duration = itemCatalog.GetDuration(id,level); 
                    realDuration = duration * 50;
                    break;
            case 4: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    countMax = 3;
                    interval = realDuration / countMax;
                    break;
            case 5: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;
            case 6: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    countMax = 12;
                    interval = realDuration / countMax;
                    break;
            case 7: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    countMax = 3;
                    interval = realDuration / countMax;
                    break;
            case 8: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;
            case 9: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;
            case 10:duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;
            case 11:duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;
            case 12:duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;
            case 13:duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;
            case 14:duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;


            case 18: duration = itemCatalog.GetDuration(id,level);
                    realDuration = duration * 50;
                    break;
            default: break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = player.transform.position;
        timer++;
        //Debug.Log(timer);
        switch (id)
        {
            case 0: timer = FireMelee(timer); break;

            case 1: timer = WaterMelee(timer); break;

            case 2: timer = EarthMelee(timer); break;

            case 3: timer = AirMelee(timer); break;

            case 4: timer = PoisonMelee(timer); break;

            case 5: timer = FireRanged(timer); break;

            case 6: timer = WaterRanged(timer); break;

            case 7: timer = EarthRanged(timer); break;

            case 8: timer = AirRanged(timer); break;

            case 9: timer = PoisonRanged(timer); break;

            case 10: timer = FireUtility(timer); break;

            case 11: timer = WaterUtility(timer); break;

            case 12: timer = EarthUtility(timer); break;

            case 13: timer = AirUtility(timer); break;

            case 14: timer = PoisonUtility(timer); break;


            case 18: timer = ExplosionMelee(timer); break;

            default: break;
        }


    }

    public void Setup(int id, int level)
    {
        itemCatalog = GameObject.FindGameObjectWithTag("Logic").GetComponent<ItemCatalogScript>();
        player = GameObject.Find("Player");
        this.id = id;
        this.level = level;

        frequency = itemCatalog.GetFrequency(id,level);
        realFrequency = frequency * 50;
    }

    public int GetId()
    {
        return this.id;
    }

    public int GetLevel()
    {
        return this.level;
    }

    public void CheckLevel()
    {
        int currLvl = level;
        this.level = itemCatalog.GetCurrLevel(id);
        //Debug.Log(currLvl + " a " + level);
        if(currLvl != level)
        {
            frequency = itemCatalog.GetFrequency(id,level);
            Start();
        }
    }

    
    private int FireMelee(int timer)
    {
        if( timer == (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            attackObj.GetComponent<Renderer>().enabled = false;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }

    private int EarthMelee(int timer)
    {
        if( timer == (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            attackObj.GetComponent<Renderer>().enabled = false;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }

    private int WaterMelee(int timer)
    {   
        if( timer == (int)realFrequency)
        {
            for(int i = count; i <= countMax; i++)
            {
                CheckLevel();
                attackObj = itemCatalog.GetItem(id);
                Vector3 location = player.transform.position;
                attackObj.GetComponent<AttackWaterMeleeScript>().SetCount(i);
                attackObj.GetComponent<Renderer>().enabled = false;
                Instantiate( attackObj, location, Quaternion.identity);
            }
        
            return -(int)realDuration;
        }

        return timer;
    }

    private int AirMelee(int timer)
    {
        if( timer == (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            Instantiate( attackObj, location, Quaternion.identity);
            return 0-(int)realDuration;
        }
        return timer;
    }

    private int PoisonMelee(int timer)
    {        
        if( timer == (int)realFrequency && activeAtk == false)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            attackObj.GetComponent<AttackPoisonMeleeScript>().SetCount(count);
            attackObj.GetComponent<Renderer>().enabled = false;
            Instantiate( attackObj, location, Quaternion.identity);
            count++;
            activeAtk = true;
            return 0;
        }else if( timer == (int)interval && activeAtk == true)
        {
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            attackObj.GetComponent<AttackPoisonMeleeScript>().SetCount(count);
            attackObj.GetComponent<Renderer>().enabled = false;
            Instantiate( attackObj, location, Quaternion.identity);
            count++;
            if(countMax < count)
            {
                activeAtk = false;
                count = 1;
                return -(int)realDuration;
            }
            return 0;
        }
        return timer;
    }
    
    private int FireRanged(int timer)
    {
        if( timer == (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }

    private int WaterRanged(int timer)
    {
        if( timer == (int)realFrequency && !activeAtk)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            attackObj.GetComponent<AttackWaterRangedScript>().SetOffset(WaterRangedOffset(count));
            attackObj.GetComponent<Renderer>().enabled = false;
            Instantiate( attackObj, location, Quaternion.identity);
            activeAtk = true;
            count++;
            return 0;
        }else if(timer == (int)interval && activeAtk){
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            attackObj.GetComponent<AttackWaterRangedScript>().SetOffset(WaterRangedOffset(count));
            attackObj.GetComponent<Renderer>().enabled = false;
            Instantiate( attackObj, location, Quaternion.identity);
            count++;
            if(count > countMax)
            {
                activeAtk = false;
                count = 1;
                return -(int)realDuration;
            }
            return 0;
        }
        return timer;
    }

    private int[] WaterRangedOffset(int count)
    {
        int[] offset = new int[2];
        int offsetX,offsetY;
        switch(count)
        {
            case 1: offsetX = 0;
                    offsetY = UnityEngine.Random.Range(2,6);
                    break;
            case 2: offsetX = 2;
                    offsetY = UnityEngine.Random.Range(-2,3);
                    break;
            case 3: offsetX = -2;
                    offsetY = UnityEngine.Random.Range(-2,3);
                    break;
            case 4: offsetX = 0;
                    offsetY = UnityEngine.Random.Range(-5,-1);
                    break;
            case 5: offsetX = -2;
                    offsetY = UnityEngine.Random.Range(5,9);
                    break;
            case 6: offsetX = 2;
                    offsetY = UnityEngine.Random.Range(5,9);
                    break;
            case 7: offsetX = -4;
                    offsetY = UnityEngine.Random.Range(2,6);
                    break;
            case 8: offsetX = 4;
                    offsetY = UnityEngine.Random.Range(2,6);
                    break;
            case 9: offsetX = -4;
                    offsetY = UnityEngine.Random.Range(-5,-1);
                    break;
            case 10: offsetX = 4;
                    offsetY = UnityEngine.Random.Range(-5,-1);
                    break;
            case 11: offsetX = -2;
                    offsetY = UnityEngine.Random.Range(-8,-4);
                    break;
            case 12: offsetX = 2;
                    offsetY = UnityEngine.Random.Range(-8,-4);
                    break;

            default: 
                    offsetX = 1;
                    offsetY = 1;
                    break;
        }
        offset[0] = offsetX;
        offset[1] = offsetY;

        return offset;
    }


    private int EarthRanged(int timer)
    {
        if( timer == (int)realFrequency && activeAtk == false)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            attackObj.GetComponent<AttackEarthRangedScript>().SetCount(count);
            Instantiate( attackObj, location, Quaternion.identity);
            count++;
            activeAtk = true;
            return 0;
        }else if( timer == (int)interval && activeAtk == true)
        {
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            attackObj.GetComponent<AttackEarthRangedScript>().SetCount(count);
            Instantiate( attackObj, location, Quaternion.identity);
            count++;
            if(countMax < count)
            {
                activeAtk = false;
                count = 1;
                return -(int)realDuration;
            }
            return 0;
        }
        return timer;
    }

    private int AirRanged(int timer)
    {
        if( timer == (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }

    private int PoisonRanged(int timer)
    {
        if( timer == (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            //attackObj.GetComponent<AttackPoisonRangedScript>().SetDirection(right);
            attackObj.GetComponent<AttackPoisonRangedScript>().right = right;
            Instantiate( attackObj, location, Quaternion.identity);
            right = !right;
            return -(int)realDuration;
        }
        return timer;
    }

    private int FireUtility(int timer)
    {
        if ( timer >= (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }

    private int WaterUtility(int timer)
    {
        if ( timer >= (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }

    private int EarthUtility(int timer)
    {
        if ( timer >= (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }

    private int AirUtility(int timer)
    {
        if ( timer >= (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }

    private int PoisonUtility(int timer)
    {
        if ( timer >= (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }



    private int ExplosionMelee(int timer)
    {
        if( timer == (int)realFrequency)
        {
            CheckLevel();
            attackObj = itemCatalog.GetItem(id);
            Vector3 location = player.transform.position;
            attackObj.GetComponent<Renderer>().enabled = false;
            Instantiate( attackObj, location, Quaternion.identity);
            return -(int)realDuration;
        }
        return timer;
    }

}
