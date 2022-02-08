using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;


   [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;
    

    AudioSource audiosource;

    bool isTransitioning = false;
    bool collisionDisable = false;

    void Start() 
    {
        audiosource = GetComponent<AudioSource>();
    }
    void Update() 
    {
        debugControls();
    }
  
     void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionDisable) { return;}
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                print("All Gucci BrO");
                break;
            case "Fuel":
                print("Drinnk UP boys");
                Destroy(other.gameObject);
                
                break;
            case "Finish":
            //audio success noise plays
              
                print("We did it boys");
                NextLevelSequence();
                break;
            default:
            //audio death sound plays
                
                print("You have DiEd, RIP");
                //Destroy(gameObject);
                CrashSequence();
                break;
                
        }
    }
    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadNextLevel()
    {
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = currentSceneIndex + 1;
        if(NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;
        }
        SceneManager.LoadScene(NextSceneIndex);
    }
    public void CrashSequence()
    {
        audiosource.Stop();
        isTransitioning = true;
        audiosource.PlayOneShot(death, 1f);
         deathParticles.Play();
        GetComponent<Rocket>().enabled = false;
        Invoke("ReloadLevel" , levelLoadDelay);
        
    }
    
    void NextLevelSequence()
    {
        audiosource.Stop();
        isTransitioning = true;
        audiosource.PlayOneShot(success, 1f);
        successParticles.Play();
        GetComponent<Rocket>().enabled = false;
        Invoke("LoadNextLevel" , levelLoadDelay);
    }
    
       void debugControls()
    {
        if (Input.GetKeyDown(KeyCode.L))
            {
            LoadNextLevel();
            }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable; //toggle collision
        }
        
    }
    
   
}
