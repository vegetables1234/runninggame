using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;        //variable to link back to main menu

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenuLevel);
    }
}

