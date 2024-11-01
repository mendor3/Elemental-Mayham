using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCatalogScript : MonoBehaviour
{
    public GameObject fireMelee, waterMelee, earthMelee, airMelee, poisonMelee;
    public GameObject fireRanged, waterRanged, earthRanged, airRanged, poisonRanged;
    public GameObject fireUtility, waterUtility, earthUtility, airUtility, poisonUtility;
    public GameObject energyMelee, lavaMelee, lightningMelee, explosionMelee, natureMelee, iceMelee, acidMelee, metalMelee, radiationMelee, gasMelee;
    public GameObject energyRanged, lavaRanged, lightningRanged, explosionRanged, natureRanged, iceRanged, acidRanged, metalRanged, radiationRanged, gasRanged;
    public GameObject energyUtility, lavaUtility, lightningUtility, explosionUtility, natureUtility, iceUtility, acidUtility, metalUtility, radiationUtility, gasUtility;
    
    public bool poisonEffect = false;

    private int FM = 0, WM = 0, EM = 0, AM = 0, PM = 0,
                FR = 0, WR = 0, ER = 0, AR = 0, PR = 0,
                FU = 0, WU = 0, EU = 0, AU = 0, PU = 0;

    private int EnM = 0, EnR = 0, EnU = 0,
                LaM = 0, LaR = 0, LaU = 0,
                LiM = 0, LiR = 0, LiU = 0,
                ExM = 0, ExR = 0, ExU = 0,
                NaM = 0, NaR = 0, NaU = 0,
                IcM = 0, IcR = 0, IcU = 0,
                AcM = 0, AcR = 0, AcU = 0,
                MeM = 0, MeR = 0, MeU = 0,
                RaM = 0, RaR = 0, RaU = 0,
                GaM = 0, GaR = 0, GaU = 0;

    public GameObject GetItem(int id)
    {
        switch (id)
        {
            case 0: return fireMelee;
            
            case 1: return waterMelee;

            case 2: return earthMelee;

            case 3: return airMelee;

            case 4: return poisonMelee;

            case 5: return fireRanged;

            case 6: return waterRanged;

            case 7: return earthRanged;

            case 8: return airRanged;

            case 9: return poisonRanged;

            case 10: return fireUtility;

            case 11: return waterUtility;

            case 12: return earthUtility;

            case 13: return airUtility;

            case 14: return poisonUtility;

            case 15: return energyMelee;

            case 16: return lavaMelee;

            case 17: return lightningMelee;

            case 18: return explosionMelee;

            case 19: return natureMelee;

            case 20: return iceMelee;

            case 21: return acidMelee;

            case 22: return metalMelee;

            case 23: return radiationMelee;

            case 24: return gasMelee;

            case 25: return energyRanged;

            case 26: return lavaRanged;

            case 27: return lightningRanged;

            case 28: return explosionRanged;

            case 29: return natureRanged;

            case 30: return iceRanged;

            case 31: return acidRanged;

            case 32: return metalRanged;

            case 33: return radiationRanged;

            case 34: return gasRanged;

            case 35: return energyUtility;

            case 36: return lavaUtility;

            case 37: return lightningUtility;

            case 38: return explosionUtility;

            case 39: return natureUtility;

            case 40: return iceUtility;

            case 41: return acidUtility;

            case 42: return metalUtility;

            case 43: return radiationUtility;

            case 44: return gasUtility;


            default: return earthMelee;
            }
    }

    public int GetCombo(string element1,string element2,string type)
    {
        string combo = "";

        switch(element1,element2)
        {
            case ("fire","water"): combo = "energy"; break;
            case ("water","fire"): combo = "energy"; break;

            case ("fire","earth"): combo = "lava"; break;
            case ("earth","fire"): combo = "lava"; break;

            case ("fire","air"): combo = "lightning"; break;
            case ("air","fire"): combo = "lightning"; break;

            case ("fire","poison"): combo = "explosion"; break;
            case ("poison","fire"): combo = "explosion"; break;

            case ("water","earth"): combo = "nature"; break;
            case ("earth","water"): combo = "nature"; break;

            case ("water","air"): combo = "ice"; break;
            case ("air","water"): combo = "ice"; break;

            case ("water","poison"): combo = "acid"; break;
            case ("poison","water"): combo = "acid"; break;

            case ("earth","air"): combo = "metal"; break;
            case ("air","earth"): combo = "metal"; break;

            case ("earth","poison"): combo = "radiation"; break;
            case ("poison","earth"): combo = "radiation"; break;

            case ("air","poison"): combo = "gas"; break;
            case ("poison","air"): combo = "gas"; break;

        }

        switch(type)
        {
            case "melee":
                switch(combo)
                {
                    case "energy": return 15;
                    case "lava": return 16;
                    case "lightning": return 17;
                    case "explosion": return 18;
                    case "nature": return 19;
                    case "ice": return 20;
                    case "acid": return 21;
                    case "metal": return 22;
                    case "radiation": return 23;
                    case "gas": return 24;

                    default: return 999;
                }

            case "ranged":
                switch(combo)
                {
                    case "energy": return 25;
                    case "lava": return 26;
                    case "lightning": return 27;
                    case "explosion": return 28;
                    case "nature": return 29;
                    case "ice": return 30;
                    case "acid": return 31;
                    case "metal": return 32;
                    case "radiation": return 33;
                    case "gas": return 34;

                    default: return 999;
                }

            case "utility":
                switch(combo)
                {
                    case "energy": return 35;
                    case "lava": return 36;
                    case "lightning": return 37;
                    case "explosion": return 38;
                    case "nature": return 39;
                    case "ice": return 40;
                    case "acid": return 41;
                    case "metal": return 42;
                    case "radiation": return 43;
                    case "gas": return 44;

                    default: return 999;
                }
            
            default: return 999;
        } 


    }

    public string GetElement(int id)
    {
        switch(id)
        {
            case 0: return "fire";
            case 5: return "fire";
            case 10: return "fire";

            case 1: return "water";
            case 6: return "water";
            case 11: return "water";

            case 2: return "earth";
            case 7: return "earth";
            case 12: return "earth";

            case 3: return "air";
            case 8: return "air";
            case 13: return "air";

            case 4: return "poison";
            case 9: return "poison";
            case 14: return "poison";
            
            default: return "complex";
        }
    }

    public string GetType(int id)
    {
        switch(id)
        {
            case 0: return "melee";
            case 1: return "melee";
            case 2: return "melee";
            case 3: return "melee";
            case 4: return "melee";

            case 5: return "ranged";
            case 6: return "ranged";
            case 7: return "ranged";
            case 8: return "ranged";
            case 9: return "ranged";

            case 10: return "utility";
            case 11: return "utility";
            case 12: return "utility";
            case 13: return "utility";
            case 14: return "utility";
            
            default: return "complex";
        }
    }

    /* time from last cast in seconds */
    public float GetFrequency(int id, int level)
    {
        switch ((id,level))
        {   
            case (0,1): return 2;
            case (0,2): return 1.95f;
            case (0,3): return 1.9f;
            case (0,4): return 1.85f;
            case (0,5): return 1.8f;
            case (0,6): return 1.75f;

            case (1,1): return 2;
            case (1,2): return 1.95f;
            case (1,3): return 1.9f;
            case (1,4): return 1.85f;
            case (1,5): return 1.8f;
            case (1,6): return 1.75f;

            case (2,1): return 6;
            case (2,2): return 5.8f;
            case (2,3): return 5.6f;
            case (2,4): return 5.4f;
            case (2,5): return 5.2f;
            case (2,6): return 5;

            case (3,1): return 3;
            case (3,2): return 2.9f;
            case (3,3): return 2.75f;
            case (3,4): return 2.6f;
            case (3,5): return 2.4f;
            case (3,6): return 2.1f;

            case (4,1): return 2;
            case (4,2): return 1.95f;
            case (4,3): return 1.9f;
            case (4,4): return 1.85f;
            case (4,5): return 1.8f;
            case (4,6): return 1.75f;

            case (5,1): return 6;
            case (5,2): return 5.8f;
            case (5,3): return 5.6f;
            case (5,4): return 5.4f;
            case (5,5): return 5.2f;
            case (5,6): return 5f;

            case (6,1): return 3;
            case (6,2): return 2.8f;
            case (6,3): return 2.6f;
            case (6,4): return 2.4f;
            case (6,5): return 2.2f;
            case (6,6): return 2f;

            case (7,1): return 6;
            case (7,2): return 5.8f;
            case (7,3): return 5.6f;
            case (7,4): return 5.4f;
            case (7,5): return 5.2f;
            case (7,6): return 5f;

            case (8,1): return 1;
            case (8,2): return 0.9f;
            case (8,3): return 0.8f;
            case (8,4): return 0.7f;
            case (8,5): return 0.6f;
            case (8,6): return 0.5f;

            case (9,1): return 3;
            case (9,2): return 2.8f;
            case (9,3): return 2.6f;
            case (9,4): return 2.4f;
            case (9,5): return 2.2f;
            case (9,6): return 2f;

            case (10,1): return 0;
            case (10,2): return 0;
            case (10,3): return 0;
            case (10,4): return 0;
            case (10,5): return 0;
            case (10,6): return 0;

            case (11,1): return 5;
            case (11,2): return 4;
            case (11,3): return 3;
            case (11,4): return 2;
            case (11,5): return 1;
            case (11,6): return 0;

            case (12,1): return 5;
            case (12,2): return 5;
            case (12,3): return 4;
            case (12,4): return 4;
            case (12,5): return 3;
            case (12,6): return 2;

            case (13,1): return 0;
            case (13,2): return 0;
            case (13,3): return 0;
            case (13,4): return 0;
            case (13,5): return 0;
            case (13,6): return 0;

            case (14,1): return 3;
            case (14,2): return 2.8f;
            case (14,3): return 2.6f;
            case (14,4): return 2.4f;
            case (14,5): return 2.2f;
            case (14,6): return 2f;

            
            case (18,1): return 5;
            case (18,2): return 4.5f;
            case (18,3): return 4;
            case (18,4): return 3.5f;
            case (18,5): return 3;
            case (18,6): return 2.5f;

            case (28,1): return 5;
            case (28,2): return 4.5f;
            case (28,3): return 4;
            case (28,4): return 3.5f;
            case (28,5): return 3;
            case (28,6): return 2.5f;

            default: return 1;
            }
    }

    /* how long does attack stay on screen - doesnt apply for ranged?*/
    public float GetDuration(int id, int level)
    {
        switch ((id,level)) 
        {
            case (0,1): return 1.5f;
            case (0,2): return 1.6f;
            case (0,3): return 1.7f;
            case (0,4): return 1.8f;
            case (0,5): return 1.9f;
            case (0,6): return 2;

            case (1,1): return 1;
            case (1,2): return 1.05f;
            case (1,3): return 1.1f;
            case (1,4): return 1.15f;
            case (1,5): return 1.2f;
            case (1,6): return 1.25f;

            case (2,1): return 3;
            case (2,2): return 3.25f;
            case (2,3): return 3.5f;
            case (2,4): return 4;
            case (2,5): return 4.5f;
            case (2,6): return 5;

            case (3,1): return 0.5f;
            case (3,2): return 0.5f;
            case (3,3): return 0.55f;
            case (3,4): return 0.55f;
            case (3,5): return 0.60f;
            case (3,6): return 0.65f;

            case (4,1): return 1;
            case (4,2): return 1.05f;
            case (4,3): return 1.1f;
            case (4,4): return 1.15f;
            case (4,5): return 1.2f;
            case (4,6): return 1.25f;

            case (5,1): return 3;
            case (5,2): return 3;
            case (5,3): return 3;
            case (5,4): return 3;
            case (5,5): return 3;
            case (5,6): return 3;

            case (6,1): return 1.8f;
            case (6,2): return 1.9f;
            case (6,3): return 2f;
            case (6,4): return 2.1f;
            case (6,5): return 2.3f;
            case (6,6): return 2.5f;

            case (7,1): return 3f;
            case (7,2): return 3f;
            case (7,3): return 4f;
            case (7,4): return 4f;
            case (7,5): return 5f;
            case (7,6): return 5f;

            case (8,1): return 4;
            case (8,2): return 4;
            case (8,3): return 4;
            case (8,4): return 4;
            case (8,5): return 4;
            case (8,6): return 4;

            case (9,1): return 3;
            case (9,2): return 3;
            case (9,3): return 3;
            case (9,4): return 3;
            case (9,5): return 3;
            case (9,6): return 3;

            case (10,1): return 10;
            case (10,2): return 10;
            case (10,3): return 10;
            case (10,4): return 10;
            case (10,5): return 10;
            case (10,6): return 10;

            case (11,1): return 5;
            case (11,2): return 5;
            case (11,3): return 5;
            case (11,4): return 5;
            case (11,5): return 5;
            case (11,6): return 5;

            case (12,1): return 3;
            case (12,2): return 4;
            case (12,3): return 5;
            case (12,4): return 6;
            case (12,5): return 7;
            case (12,6): return 8;

            case (13,1): return 60;
            case (13,2): return 60;
            case (13,3): return 60;
            case (13,4): return 60;
            case (13,5): return 60;
            case (13,6): return 60;

            case (14,1): return 3;
            case (14,2): return 2.8f;
            case (14,3): return 2.6f;
            case (14,4): return 2.4f;
            case (14,5): return 2.2f;
            case (14,6): return 2f;


            case (18,1): return 0.8f;
            case (18,2): return 0.9f;
            case (18,3): return 1;
            case (18,4): return 1.1f;
            case (18,5): return 1.25f;
            case (18,6): return 1.4f;

            case (28,1): return 3;
            case (28,2): return 3f;
            case (28,3): return 3;
            case (28,4): return 3f;
            case (28,5): return 3;
            case (28,6): return 3f;


            default: return 1;
        }
    }

    public float getDemage(int id, int level)
    {
        switch ((id , level)) 
        {
            case (0,1): return 7;
            case (0,2): return 9;
            case (0,3): return 11.5f;
            case (0,4): return 15;
            case (0,5): return 19;
            case (0,6): return 24;

            case (1,1): return 2;
            case (1,2): return 2.5f;
            case (1,3): return 3;
            case (1,4): return 4;
            case (1,5): return 5.5f;
            case (1,6): return 7;

            case (2,1): return 9;
            case (2,2): return 11;
            case (2,3): return 14;
            case (2,4): return 19;
            case (2,5): return 25;
            case (2,6): return 32;

            case (3,1): return 20;
            case (3,2): return 26;
            case (3,3): return 33;
            case (3,4): return 42;
            case (3,5): return 53;
            case (3,6): return 65;

            case (4,1): return 2;
            case (4,2): return 2.5f;
            case (4,3): return 3;
            case (4,4): return 4;
            case (4,5): return 5.5f;
            case (4,6): return 7;

            case (5,1): return 20;
            case (5,2): return 26;
            case (5,3): return 33;
            case (5,4): return 42;
            case (5,5): return 53;
            case (5,6): return 65;

            case (6,1): return 2;
            case (6,2): return 2.5f;
            case (6,3): return 3;
            case (6,4): return 4;
            case (6,5): return 5.5f;
            case (6,6): return 7;

            case (7,1): return 5;
            case (7,2): return 7;
            case (7,3): return 10;
            case (7,4): return 13;
            case (7,5): return 16;
            case (7,6): return 20;

            case (8,1): return 3;
            case (8,2): return 2.8f;
            case (8,3): return 2.6f;
            case (8,4): return 2.4f;
            case (8,5): return 2.2f;
            case (8,6): return 2f;

            case (9,1): return 1;
            case (9,2): return 1.2f;
            case (9,3): return 1.4f;
            case (9,4): return 1.6f;
            case (9,5): return 1.8f;
            case (9,6): return 2f;

            case (10,1): return 1;
            case (10,2): return 1;
            case (10,3): return 1;
            case (10,4): return 1;
            case (10,5): return 1;
            case (10,6): return 1;

            case (11,1): return 1;
            case (11,2): return 1;
            case (11,3): return 1;
            case (11,4): return 1;
            case (11,5): return 1;
            case (11,6): return 1;

            case (12,1): return 3;
            case (12,2): return 2.8f;
            case (12,3): return 2.6f;
            case (12,4): return 2.4f;
            case (12,5): return 2.2f;
            case (12,6): return 2f;

            case (13,1): return 5.5f;
            case (13,2): return 6;
            case (13,3): return 6.5f;
            case (13,4): return 7;
            case (13,5): return 8;
            case (13,6): return 10;

            case (14,1): return 2;
            case (14,2): return 2.2f;
            case (14,3): return 2.4f;
            case (14,4): return 2.8f;
            case (14,5): return 3.2f;
            case (14,6): return 3.5f;



            case (18,1): return 10;
            case (18,2): return 12;
            case (18,3): return 15;
            case (18,4): return 18;
            case (18,5): return 22;
            case (18,6): return 27;

            case (28,1): return 10;
            case (28,2): return 12;
            case (28,3): return 14;
            case (28,4): return 17;
            case (28,5): return 20;
            case (28,6): return 24;


            default: return 1;
        }
    }

    public int GetCurrLevel(int id)
    {
        switch (id)
        {
            case 0: return FM;
            
            case 1: return WM;

            case 2: return EM;

            case 3: return AM;

            case 4: return PM;

            case 5: return FR;

            case 6: return WR;

            case 7: return ER;

            case 8: return AR;

            case 9: return PR;

            case 10: return FU;

            case 11: return WU;

            case 12: return EU;

            case 13: return AU;

            case 14: return PU;


            case 18: return ExM;

            default: return 1;
            }
    }

    public void LevelUp(int id)
    {
        switch (id)
        {
            case 0: FM++; break;
            
            case 1: WM++; break;

            case 2: EM++; break;

            case 3: AM++; break;

            case 4: PM++; break;

            case 5: FR++; break;

            case 6: WR++; break;
            
            case 7: ER++; break;

            case 8: AR++; break;

            case 9: PR++; break;

            case 10: FU++; break;

            case 11: WU++; break;

            case 12: EU++; break;

            case 13: AU++; break;

            case 14: PU++; break;


            case 18: ExM++; break;
            }
    }

    public float GetPoisonPassive()
    {
        return getDemage(14,PU);
    }

    public Sprite getSprite(int id)
    {
        switch (id)
        {
            case 0: return fireMelee.GetComponent<SpriteRenderer>().sprite;
            
            case 1: return waterMelee.GetComponent<SpriteRenderer>().sprite;

            case 2: return earthMelee.GetComponent<SpriteRenderer>().sprite;

            case 3: return airMelee.GetComponent<SpriteRenderer>().sprite;

            case 4: return poisonMelee.GetComponent<SpriteRenderer>().sprite;

            case 5: return fireRanged.GetComponent<SpriteRenderer>().sprite;

            case 6: return waterRanged.GetComponent<SpriteRenderer>().sprite;

            case 7: return earthRanged.GetComponent<SpriteRenderer>().sprite;

            case 8: return airRanged.GetComponent<SpriteRenderer>().sprite;

            case 9: return poisonRanged.GetComponent<SpriteRenderer>().sprite;

            case 10: return fireUtility.GetComponent<SpriteRenderer>().sprite;

            case 11: return waterUtility.GetComponent<SpriteRenderer>().sprite;

            case 12: return earthUtility.GetComponent<SpriteRenderer>().sprite;

            case 13: return airUtility.GetComponent<SpriteRenderer>().sprite;

            case 14: return poisonUtility.GetComponent<SpriteRenderer>().sprite;

            case 15: return energyMelee.GetComponent<SpriteRenderer>().sprite;

            case 16: return lavaMelee.GetComponent<SpriteRenderer>().sprite;

            case 17: return lightningMelee.GetComponent<SpriteRenderer>().sprite;

            case 18: return explosionMelee.GetComponent<SpriteRenderer>().sprite;

            case 19: return natureMelee.GetComponent<SpriteRenderer>().sprite;;

            case 20: return iceMelee.GetComponent<SpriteRenderer>().sprite;

            case 21: return acidMelee.GetComponent<SpriteRenderer>().sprite;

            case 22: return metalMelee.GetComponent<SpriteRenderer>().sprite;

            case 23: return radiationMelee.GetComponent<SpriteRenderer>().sprite;

            case 24: return gasMelee.GetComponent<SpriteRenderer>().sprite;;

            case 25: return energyRanged.GetComponent<SpriteRenderer>().sprite;

            case 26: return lavaRanged.GetComponent<SpriteRenderer>().sprite;

            case 27: return lightningRanged.GetComponent<SpriteRenderer>().sprite;

            case 28: return explosionRanged.GetComponent<SpriteRenderer>().sprite;

            case 29: return natureRanged.GetComponent<SpriteRenderer>().sprite;

            case 30: return iceRanged.GetComponent<SpriteRenderer>().sprite;

            case 31: return acidRanged.GetComponent<SpriteRenderer>().sprite;

            case 32: return metalRanged.GetComponent<SpriteRenderer>().sprite;

            case 33: return radiationRanged.GetComponent<SpriteRenderer>().sprite;

            case 34: return gasRanged.GetComponent<SpriteRenderer>().sprite;

            case 35: return energyUtility.GetComponent<SpriteRenderer>().sprite;

            case 36: return lavaUtility.GetComponent<SpriteRenderer>().sprite;

            case 37: return lightningUtility.GetComponent<SpriteRenderer>().sprite;

            case 38: return explosionUtility.GetComponent<SpriteRenderer>().sprite;

            case 39: return natureUtility.GetComponent<SpriteRenderer>().sprite;

            case 40: return iceUtility.GetComponent<SpriteRenderer>().sprite;

            case 41: return acidUtility.GetComponent<SpriteRenderer>().sprite;

            case 42: return metalUtility.GetComponent<SpriteRenderer>().sprite;

            case 43: return radiationUtility.GetComponent<SpriteRenderer>().sprite;

            case 44: return gasUtility.GetComponent<SpriteRenderer>().sprite;


            default: return earthMelee.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public string GetName(int id)
    {
        switch (id)
        {
            case 0: return "Fire Melee";
            
            case 1: return "Water Melee";

            case 2: return "Earth Melee";

            case 3: return "Air Melee";

            case 4: return "Poison Melee";

            case 5: return "Fire Ranged";

            case 6: return "Water Ranged";

            case 7: return "Earth Ranged";

            case 8: return "Air Ranged";

            case 9: return "Poison Ranged";

            case 10: return "Fire Utility";

            case 11: return "Water Utility";

            case 12: return "Earth Utility";

            case 13: return "Air Utility";

            case 14: return "Poison Utility";

            case 15: return "Energy Melee";

            case 16: return "Lava Melee";

            case 17: return "Lightning Melee";

            case 18: return "Explosion Melee";

            case 19: return "Nature Melee";

            case 20: return "Ice Melee";

            case 21: return "Acid Melee";

            case 22: return "Metal Melee";

            case 23: return "Radiation Melee";

            case 24: return "Gas Melee";

            case 25: return "Energy Ranged";

            case 26: return "Lava Ranged";

            case 27: return "Lightning Ranged";

            case 28: return "Explosion Ranged";

            case 29: return "Nature Ranged";

            case 30: return "Ice Ranged";

            case 31: return "Acid Ranged";

            case 32: return "Metal Ranged";

            case 33: return "Radiation Ranged";

            case 34: return "Gas Ranged";

            case 35: return "Energy Utility";

            case 36: return "Lava Utility";

            case 37: return "Lightning Utility";

            case 38: return "Explosion Utility";

            case 39: return "Nature Utility";

            case 40: return "Ice Utility";

            case 41: return "Acid Utility";

            case 42: return "Metal Utility";

            case 43: return "Radiation Utility";

            case 44: return "Gas Utility";


            default: return "Earth Melee";
        }
    }
}
