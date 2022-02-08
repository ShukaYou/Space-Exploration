using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButtonsandstuff : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public GameObject strtButton;

    bool wantsToQuit = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        wantsToQuit = true;
        Application.Quit();
    }
     public void LoadNextLevel()
    {
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       print(currentSceneIndex);
        int NextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(NextSceneIndex);
    }
}
