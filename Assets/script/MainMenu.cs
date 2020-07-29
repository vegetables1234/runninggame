using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

//simple code that can't really be changed --> adapted from gamesplusjames from 10/7/20
// https://www.youtube.com/watch?v=zXCJF8cBVdE&list=PLiyfvmtjWC_XmdYfXm2i1AQ3lKrEPgc9-&index=16
{
    public string playGameLevel;

    public void PlayGame()
    {
       SceneManager.LoadScene(playGameLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
