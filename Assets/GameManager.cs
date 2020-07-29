using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerControl thePlayer;
    private Vector3 playerStartPoint;

    private TimerManager timeManager;

    public DeathMenu theDeathScreen;


    /* this module is adapted from gamesplusjames from https://www.youtube.com/watch?v=d06ljVEAd78&t=1s
     * on the 8/07/20 
     * The main difference lies in the fact that this programmer used an index to restart his game 
     * whereas I simply deactivate the entire scene to use minimal code
     */
    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = new Vector3(this.transform.position.x, this.transform.position.y + 10);
        //thePlayer.transform.position
        timeManager = FindObjectOfType<TimerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()   //calls the Coroutine RestartGameCo
    {
        timeManager.timerIncreasing = false;
        thePlayer.gameObject.SetActive(false);          //I changed this to suit my code - c

        theDeathScreen.gameObject.SetActive(true);

    }

    public void Reset()
    {
        SceneManager.LoadScene("Nova");
        
    }


        
} 

