using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public static bool PlayerIsDead = false;
    public GameObject PauseMenuUI;
    public GameObject DeadMenuUI;
    public GameObject ScoreboardUI;
    public Text score;
    public static bool menuSelector = false;
    public static float scoreText;
    public static bool addScore = false;
    private int whichMenu;
    private bool onScore = false;

    void Start()
    {
        score = GetComponentInChildren<Text>();
        GameIsPaused = false;
    ScoreboardUI.SetActive(true);
        ScoreboardUI.SetActive(false);

    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && menuSelector==false && onScore == false)
        {
            whichMenu = 1;
            if (GameIsPaused)
            {
                Resume();
                whichMenu = 0;
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
            whichMenu = 2;
            addScore = true;
            if (PlayerIsDead)
            {
                Restart();
                DeadMenuUI.SetActive(false);
                whichMenu = 0;
                Debug.Log(ScoreBoard.scoreCount);
            }
            else
            {
                DeadPause();
            }

            
        }
        Player_Movement.isDead = false;

        
        score.text = "" + Player_Movement.scoreValue;
        scoreText = int.Parse(score.text);

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
        PlayerIsDead = false;
        DeadMenuUI.SetActive(false);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        DeadMenuUI.SetActive(false);
        PlayerIsDead = false;
        GameIsPaused = false;
        menuSelector = false;
        Time.timeScale = 1f;
        DeadMenuUI.SetActive(false);
    }

    public void LoadMenu()
    {
        
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    
    }

    public void ToScoreboard()
    {
        onScore = true;
        DeadMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        ScoreboardUI.SetActive(true);       
    }

    public void BackToMenu()
    {
        if (whichMenu == 1)
        {
            onScore = false;
            ScoreboardUI.SetActive(false);
            PauseMenuUI.SetActive(true);
        }
        else if (whichMenu == 2)
        {
            ScoreboardUI.SetActive(false);
            DeadMenuUI.SetActive(true);
        }
    }
}
