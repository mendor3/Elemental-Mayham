using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpScript : MonoBehaviour
{
    public int hp = 100;
    public Logic_script logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
    }

    //Reduces player hp but also checks if hp is 0 calls GameOver() from LogicScript also displayed new hp after reduction (reduction can be 0)
    public void TakeDemage(int demage)
    {
        hp = hp - demage;
        logic.UpdateHp(hp);
        
        if( hp == 0)
        {
            logic.GameOver();
        }
    }
}
