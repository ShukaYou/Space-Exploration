using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
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
        ProcessInput();
    }
    void ProcessInput()
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
