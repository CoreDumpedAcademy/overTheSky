using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public static bool PlayerIsDead = false;
    public GameObject PauseMenuUI; 
    public GameObject DeadMenuUI;



    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        DeadMenuUI.SetActive(false);
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
