using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;        //variable to link back to main menu

    public GameObject pauseMenu;


    public void PauseGame()             //pauses the game
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()                //for resuming the game after pausing it
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()           //same function in Death Menu - simply restarts game
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
        pauseMenu.SetActive(false);
    }

    public void QuitToMain()            //quits to main menu
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuLevel);
    }
}
