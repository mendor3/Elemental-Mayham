using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreenScript : MonoBehaviour
{
    public TMP_Text txtChoice1;
    public TMP_Text txtChoice2;
    public TMP_Text txtChoice3;

    public Image btnChoice1;
    public Image btnChoice2;
    public Image btnChoice3;
    
    public InventoryScript inventory;
    public ItemCatalogScript catalog;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    private int id1, id2, id3;


    public void Setup(int id1, int id2, int id3)
    {
        this.id1 = id1;
        this.id2 = id2;
        this.id3 = id3;
        obj1 = catalog.GetItem(id1);
        obj2 = catalog.GetItem(id2);
        obj3 = catalog.GetItem(id3);
        gameObject.SetActive(true);
        Time.timeScale = 0;
        txtChoice1.text = catalog.GetName(id1);
        txtChoice2.text = catalog.GetName(id2);
        txtChoice3.text = catalog.GetName(id3);
        btnChoice1.sprite = catalog.getSprite(id1);
        btnChoice2.sprite = catalog.getSprite(id2);
        btnChoice3.sprite = catalog.getSprite(id3);
    }

    public void ChoiceButton1()
    {
        Time.timeScale = 1;
        inventory.InventoryUpdate(id1);
        gameObject.SetActive(false);
    }
    public void ChoiceButton2()
    {
        Time.timeScale = 1;
        inventory.InventoryUpdate(id2);
        gameObject.SetActive(false);
    }

    public void ChoiceButton3()
    {
        Time.timeScale = 1;
        inventory.InventoryUpdate(id3);
        gameObject.SetActive(false);
    }
}

