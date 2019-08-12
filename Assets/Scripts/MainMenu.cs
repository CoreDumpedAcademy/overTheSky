using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public static bool revive;
    private int gs;

    public GameObject MainMenuUI;
    public GameObject CreditsUI;
    public GameObject InstructionsUI;
    private GameObject deletedMusic;
    public GameObject LoadingScreen;
    public GameObject soundBtn;
    public Slider loadSlider;
    public GameObject tutorial1;
    public GameObject tutorial2;

    void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        PauseMenu.scoreArray = new int[5];
        deletedMusic = GameObject.FindGameObjectWithTag("Music");
        Destroy(deletedMusic);
    }

    public void PlayGame()
    {
        soundBtn.SetActive(false);
        LoadLevel(1);
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

    public void ToCredits()
    {
        soundBtn.SetActive(false);
        MainMenuUI.SetActive(false);
        CreditsUI.SetActive(true);
    }

    public void ToInstructions()
    {
        soundBtn.SetActive(false);
        MainMenuUI.SetActive(false);
        tutorial1.SetActive(true);
        CreditsUI.SetActive(false);
    }

    public void ToInstructions2()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
    }

    public void Back()
    {
        soundBtn.SetActive(true);
        MainMenuUI.SetActive(true);
        tutorial2.SetActive(false);
        CreditsUI.SetActive(false);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadSlider.value = progress;

            yield return null;
        }
    }
}
