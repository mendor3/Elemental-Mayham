using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatalogScript : MonoBehaviour
{
    public GameObject meleeEnemy0,meleeEnemy1, meleeEnemy2;

    public GameObject GetEnemy(int id)
    {
        switch (id)
        {
            case 0: return meleeEnemy0;
            case 1: return meleeEnemy1;
            case 2: return meleeEnemy2;

            default: return meleeEnemy0;
        }
    }
}
