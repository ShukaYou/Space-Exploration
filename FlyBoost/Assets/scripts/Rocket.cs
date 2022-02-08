using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float MainThrust = 100f;
    [SerializeField] public GameObject Player;
    [SerializeField] public AudioClip rocket;


    [SerializeField] ParticleSystem mainThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    Rigidbody rigidBody;
     AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
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
            StartThrusting();
        }   
        else
        {
            StopThrusting();
        }
            
    }

   

    void StartThrusting()
    {

        //print("Time to liftoff");
        rigidBody.AddRelativeForce(Vector3.up * MainThrust);
        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(rocket, 0.4F);

        }
        if (!mainThrusterParticles.isPlaying)
        {
            mainThrusterParticles.Play();
            print("boom particle");
        }

    }
    void StopThrusting()
    {
        audiosource.Stop();
        mainThrusterParticles.Stop();
    }
    void Rotate()
        {
        
        rigidBody.freezeRotation = true; //take manual control of rotation   
        
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
           {rotateRight(rotationThisFrame);
            Debug.Log("Heyy im turning right");} 
        
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rotateLeft(rotationThisFrame);
        else
        {
            StopRotating();
        }
            
        rigidBody.freezeRotation = false; //resume physics control of rotation
        }

    void StopRotating()
    {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }

    void rotateLeft(float rotationThisFrame)
    {

        //print("Engage left thruster!");
        transform.Rotate(Vector3.back * rotationThisFrame);
        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }
    void rotateRight(float rotationThisFrame)
    {

        //print("Engage right thruster!");
        transform.Rotate(Vector3.forward * rotationThisFrame);
        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }

    }
}
