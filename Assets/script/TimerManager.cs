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
    public float hours;

    public float pointsPerSecond;

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
    void Update()
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
        File.WriteAllText(fileName, bestTime.ToString());
    }

    public string ReadHighScore()
    {
        string fileName = "HighScore.txt";
        return File.ReadAllText(fileName);
    }
}
