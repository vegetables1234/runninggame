using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //not used!!!! delete if possible
    public int score;

    void OnTriggerEnter2D(Collider2D other)         //this links back to another function that i dont have (used for obstacles)
    {
        if (other.CompareTag("Obstacle")) {     //make sure you add the obstacle tag to prefab??
            score++;
            Debug.Log(score);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
