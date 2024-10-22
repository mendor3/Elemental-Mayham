using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatalogScript : MonoBehaviour
{
    public GameObject meleeEnemy0,meleeEnemy1, meleeEnemy2, meleeEnemy3, meleeEnemy4;
    public GameObject rangedEnemy0;

    public GameObject GetEnemy(int id)
    {
        switch (id)
        {
            case 0: return meleeEnemy0;
            case 1: return meleeEnemy1;
            case 2: return meleeEnemy2;
            case 3: return meleeEnemy3;
            case 4: return meleeEnemy4;

            case 5: return rangedEnemy0;

            default: return meleeEnemy0;
        }
    }
}
