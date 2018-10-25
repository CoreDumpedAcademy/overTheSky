using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static bool revive = false;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        Player_Movement.isDead = false;
        revive = true;
    }

    public void QuitGame()
    {
        Debug.Log("Game out bro!");

        Application.Quit();
    }
}
