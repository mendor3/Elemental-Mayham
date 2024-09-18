using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler_script : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Options()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
