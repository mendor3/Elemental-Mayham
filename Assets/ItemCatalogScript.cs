using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCatalogScript : MonoBehaviour
{
    public GameObject fireMelee, waterMelee, earthMelee, airMelee, poisonMelee;
    public GameObject fireRanged, waterRanged, earthRanged, airRanged, poisonRanged;
    public GameObject fireUtility, waterUtility, earthUtility, airUtility, poisonUtility;

    private int FM = 1, WM = 1, EM = 1, AM = 1, PM = 1,
                FR = 1, WR = 1, ER = 1, AR = 1, PR = 1,
                FU = 1, WU = 1, EU = 1, AU = 1, PU = 1;


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

            default: return earthMelee;
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

            case (14,1): return 3;
            case (14,2): return 2.8f;
            case (14,3): return 2.6f;
            case (14,4): return 2.4f;
            case (14,5): return 2.2f;
            case (14,6): return 2f;

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
            }
    }
}
