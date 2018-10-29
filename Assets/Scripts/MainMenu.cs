using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static bool revive;
    private int gs;

    void Awake()
    {
        
        
            
                
          
    }

    void Start()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("epicidad");
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        Player_Movement.isDead = false;
        PauseMenu.PlayerIsDead = false;
        PauseMenu.menuSelector = false;
        revive = true;
        
    }

    public void QuitGame()
    {
        Debug.Log("Game out bro!");

        Application.Quit();
    }
}
