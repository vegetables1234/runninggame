using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserControl : MonoBehaviour
{
    public Transform followTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()                      //eraserwall follows player/camera and deletes platform
    {
      this.transform.position = new Vector3(followTransform.position.x-25, this.transform.position.y, followTransform.position.z); 
    }
    
}
