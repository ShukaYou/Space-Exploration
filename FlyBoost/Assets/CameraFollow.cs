﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
   

     public Transform target;
     public float smoothSpeed = 0.125f;
     public Vector3 offset;



    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
         transform.position = target.position + offset;


    }

   
}
