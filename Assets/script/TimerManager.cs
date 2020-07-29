using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class TimerManager : MonoBehaviour
{
    public Text timerText;
    public Text bestTimeText;

    public float timerCount;
    public float bestTimeCount;

    public float timer;
    public float seconds;
    public float minutes;
    

    public bool timerIncreasing;


    


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        timerIncreasing = true;
         bestTimeCount = float.Parse(ReadHighScore());

        seconds = (int)(bestTimeCount % 60);
        minutes = (int)(bestTimeCount / 60);

        bestTimeText.text = "Best Time " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }


    // Update is called once per frame
    void Update()       //adpated 10/07/20 from gamesplusjames (but has been adjusted to suit a timer rather than a point system)
                        /* from https://www.youtube.com/watch?v=9HvTwtfBaYM&list=PLiyfvmtjWC_XmdYfXm2i1AQ3lKrEPgc9-&index=12
                         */
    {
        if (timerIncreasing)
        {
           TimerCalculation();
        }


        if(timerCount > bestTimeCount)
        {
            bestTimeCount = timerCount;
            BestTimeStore();
        }     

    }

    /* TimerCalculation and BestTimeStore() adapted from VoiiDz Gamnig from https://www.youtube.com/watch?v=T1HBdQSEM-4
    */

    void TimerCalculation()
    {
        timer += Time.deltaTime;        //every frame adds time
        timerCount = timer;
        seconds = (int)(timer % 60);
        minutes = (int)(timer / 60);
        

        timerText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
 
    }

    void BestTimeStore()
    {
        seconds = (int)(bestTimeCount % 60);
        minutes = (int)(bestTimeCount / 60);

        bestTimeText.text = "Best Time " + minutes.ToString("00") + ":" + seconds.ToString("00");
        SaveHighScore(bestTimeCount);
    }

    public void SaveHighScore(float bestTime)
    {
        string fileName = "HighScore.txt";
        System.IO.File.WriteAllText(fileName, bestTime.ToString());                //get rid of count
    }

    public string ReadHighScore()
    {
        Resources.Load("HighScore.txt");
        string fileName = "HighScore.txt";
        return File.ReadAllText(fileName);
    }
}
