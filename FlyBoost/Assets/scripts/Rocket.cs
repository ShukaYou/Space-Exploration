﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Time to liftoff");
            rigidBody.AddRelativeForce(Vector3.up);
        }

        if (Input.GetKey(KeyCode.D))
        {
            print("Engage right thruster!");
            transform.Rotate(Vector3.forward);
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            print("Engage left thruster!");
            transform.Rotate(Vector3.back);
        }
    }
}
