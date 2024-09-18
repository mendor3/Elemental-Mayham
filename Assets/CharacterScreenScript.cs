using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScreenScript : MonoBehaviour
{
    public Logic_script logic;

    public void FMButton()
    {
        gameObject.SetActive(false);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
        logic.StartingItem(5);
        Time.timeScale = 1;
    }
    public void WMButton()
    {
        gameObject.SetActive(false);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
        logic.StartingItem(6);
        Time.timeScale = 1;
    }

    public void EMButton()
    {
        gameObject.SetActive(false);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
        logic.StartingItem(7);
        Time.timeScale = 1;
    }

    public void AMButton()
    {
        gameObject.SetActive(false);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
        logic.StartingItem(8);
        Time.timeScale = 1;
    }

    public void PMButton()
    {
        gameObject.SetActive(false);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
        logic.StartingItem(9);
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
