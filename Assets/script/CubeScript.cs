using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    



    void OnTriggerEnter2D(Collider2D collision)          //this is used to destroy old platforms and free up memory
    {
      if (collision.gameObject.tag == "eraser")  
       {
            Destroy(gameObject);
       }
            

   }
}
