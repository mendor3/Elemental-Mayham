using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen_script : MonoBehaviour
{
    public TMP_Text scoreText;
    public void Setup(string score) {
        gameObject.SetActive(true);
        scoreText.text = "TIME " + score;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
