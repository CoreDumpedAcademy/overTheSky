using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public static bool PlayerIsDead = false;
    public GameObject PauseMenuUI; 
    public GameObject DeadMenuUI;
    public static bool menuSelector = false; 



    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && menuSelector==false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        else if (Player_Movement.isDead == true)
        {
            PauseMenuUI.SetActive(false);
            DeadMenuUI.SetActive(true);
            menuSelector = true;
            if (PlayerIsDead)
            {
                Restart();
            }
            else
            {
                DeadPause();
            }
        }
        Player_Movement.isDead = false;


	}

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerIsDead = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void DeadPause()
    {
        DeadMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PlayerIsDead = true;
    }
    public void Restart(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        DeadMenuUI.SetActive(false);
        PlayerIsDead = false;
        GameIsPaused = false;
        menuSelector = false;
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    
    }
}
