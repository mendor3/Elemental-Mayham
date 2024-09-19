using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelScript : MonoBehaviour
{
    public int level = 1;
    public int xp = 0;
    private int xpMax = 10;
    Logic_script logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
    }

    // adds xp, checks if enough xp for level up if so calls LevelUp() if no continues and than calls XpUpdate() in logic script
    public void AddXP(int newXp)
    {
        xp = xp + newXp;
        if(xp >= xpMax)
        {
            LevelUp();
        }
        logic.XpUpdate(xp);
    }

    // increases level and xp cap, returns xp to 0 and calls LevelUpdate() in logic script
    private void LevelUp()
    {
        level++;
        xpMax = xpMax + 10;
        xp = 0;
        logic.LevelUpdate(level,xpMax);
    }
}
