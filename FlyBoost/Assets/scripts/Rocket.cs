using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float rcsThrust = 100f;
    public AudioSource audiosource;
    public AudioClip rocket;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }
    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Time to liftoff");
            rigidBody.AddRelativeForce(Vector3.up);
            audiosource.PlayOneShot(rocket, 0.4F);
        }
        else
        {
            audiosource.Stop();
        }
    }

        void Rotate()
        {
        
        rigidBody.freezeRotation = true; //take manual control of rotation   
        
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            {
                print("Engage right thruster!");
                transform.Rotate(Vector3.forward * rotationThisFrame);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                print("Engage left thruster!");
                transform.Rotate(Vector3.back * rotationThisFrame);
        }
        rigidBody.freezeRotation = false; //resume physics control of rotation
        }
    
    
}
