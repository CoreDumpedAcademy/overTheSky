using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public static bool PlayerIsDead = false;
    public bool inShop;
    public GameObject PauseMenuUI;
    public GameObject DeadMenuUI;
    public GameObject ScoreboardUI;
    public Text score;
    public static bool menuSelector = false;
    public static float scoreText;
    private float restartTime = 0.2f;
    public GameObject moveLeft;
    public GameObject moveRight;
    public GameObject pauseBtn;
    public GameObject player;
    private float waitTime = 0.1f;
    private AudioSource AS;
    public GameObject AsObject;
    public GameObject LoadingScreen;
    public Slider loadSlider;
    public GameObject ShopUI;
    public Text ShopHealth;
    public Text ShopMultiplier;
    public Text ShopScoreMultiplier;
    public Text coinsValue;
    public Text coinsValue2;
    public Text coinsValue3;
    private int healthNeededCoins;
    private int multiplierNeededCoins;
    private int scoreMultiplierNeededCoins;
    public Text Coins;
    public GameObject alert;
    public GameObject coinImage;
    public GameObject tut1;
    public GameObject tut2;
    public GameObject healthBar;
    public GameObject soundBtn;
    public GameObject buyHealthBtn;
    public GameObject buyMultiplierBtn;
    public GameObject buyScoreMultiplierBtn;

    private int scoreMultiplier;
    private int whichMenu;
    private bool onScore = false;
    public static int[] scoreArray;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        scoreMultiplier = LoadScoreMultiplier();
        inShop = false;
        scoreArray = new int[5];
        AS = AsObject.GetComponent<AudioSource>();
        waitTime = 0.1f;
        LoadData();

        GameIsPaused = false;
        ScoreboardUI.SetActive(true);
        ScoreboardUI.SetActive(false);

        if(Loadtut() == 0)
        {
            Time.timeScale = 0;
            tut1.SetActive(true);
            Savetut(1);

        }

        restartTime = 0.2f;

    }
    void Update () {

        Coins.text = Player_Movement.coins.ToString();

        if (!player.activeSelf && !PauseMenuUI.activeSelf && !DeadMenuUI.activeSelf && !ScoreboardUI.activeSelf)
        {
            waitTime -= Time.deltaTime;
            if (!player.activeSelf && !PauseMenuUI.activeSelf && !DeadMenuUI.activeSelf && !ScoreboardUI.activeSelf && waitTime<= 0)
            {
                Restart();
                waitTime = 0.1f;
            }
        }

        restartTime = restartTime - Time.deltaTime;

        if (Player_Movement.isDead == true && restartTime <= 0)
        {
            PauseMenuUI.SetActive(false);
            DeadMenuUI.SetActive(true);
            menuSelector = true;
            whichMenu = 2;
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
        pauseBtn.SetActive(true);
        soundBtn.SetActive(false);
        moveLeft.SetActive(true);
        moveRight.SetActive(true);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerIsDead = false;
    }

    public void Pause()
    {
        whichMenu = 1;
        pauseBtn.SetActive(false);
        soundBtn.SetActive(true);
        moveLeft.SetActive(false);
        moveRight.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void DeadPause()
    {
        pauseBtn.SetActive(false);
        soundBtn.SetActive(true);
        moveLeft.SetActive(false);
        moveRight.SetActive(false);
        DeadMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PlayerIsDead = true;
    }
    public void Restart(){

        SaveCoins(Player_Movement.coins);
        SaveData();
        restartTime = 0.2f;
        PlayerIsDead = false;
        DeadMenuUI.SetActive(false);
        DeadMenuUI.SetActive(false);
        PlayerIsDead = false;
        GameIsPaused = false;
        menuSelector = false;
        Time.timeScale = 1f;
        DeadMenuUI.SetActive(false);
        pauseBtn.SetActive(true);
        soundBtn.SetActive(false);
        moveLeft.SetActive(true);
        moveRight.SetActive(true);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        healthBar.SetActive(false);
        coinImage.SetActive(false);
        soundBtn.SetActive(false);
        SaveCoins(Player_Movement.coins);
        LoadLevel(0);
        Destroy(AsObject);
        SaveData();
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        SaveCoins(Player_Movement.coins);
        SaveData();

        Application.Quit();
    
    }

    public void ToShop()
    {
        if(LoadHealth() < 20)
        {
            healthNeededCoins = (LoadHealth() - 2) * 25;
            ShopHealth.text = LoadHealth().ToString();
            coinsValue.text = healthNeededCoins.ToString() + " Coins";
        }
        else
        {
            healthNeededCoins = (LoadHealth() - 2) * 25;
            ShopHealth.text = LoadHealth().ToString();
            coinsValue.text = "MAX";
            buyHealthBtn.SetActive(false);
        }

        if (LoadMultiplier() < 10)
        {
            multiplierNeededCoins = LoadMultiplier() * 500;
            ShopMultiplier.text = "X" + LoadMultiplier().ToString();
            coinsValue2.text = multiplierNeededCoins.ToString() + " Coins";
        }
        else
        {
            multiplierNeededCoins = LoadMultiplier() * 500;
            ShopMultiplier.text = "X" + LoadMultiplier().ToString();
            coinsValue2.text = "MAX";
            buyMultiplierBtn.SetActive(false);
        }

        if (LoadScoreMultiplier() < 10)
        {
            scoreMultiplierNeededCoins = LoadScoreMultiplier() * 1000;
            ShopScoreMultiplier.text = "X" + LoadScoreMultiplier().ToString();
            coinsValue3.text = scoreMultiplierNeededCoins.ToString() + " Coins";
        }
        else
        {
            scoreMultiplierNeededCoins = LoadScoreMultiplier() * 1000;
            ShopScoreMultiplier.text = "X" + LoadScoreMultiplier().ToString();
            coinsValue3.text = "MAX";
            buyScoreMultiplierBtn.SetActive(false);
        }

        healthBar.SetActive(false);
        soundBtn.SetActive(false);
        PauseMenuUI.SetActive(false);
        DeadMenuUI.SetActive(false);
        ShopUI.SetActive(true);
        coinImage.transform.position = new Vector3(coinImage.transform.position.x, coinImage.transform.position.y + 170, 0);
        Coins.transform.position = new Vector3(Coins.transform.position.x, Coins.transform.position.y + 170, 0);
        inShop = true;
    }

    public void ToScoreboard()
    {
        onScore = true;
        DeadMenuUI.SetActive(false);
        soundBtn.SetActive(false);
        PauseMenuUI.SetActive(false);
        ScoreboardUI.SetActive(true);       
    }

    public void BackToMenu()
    {
        if (whichMenu == 1)
        {
            onScore = false;
            ScoreboardUI.SetActive(false);
            ShopUI.SetActive(false);
            soundBtn.SetActive(true);
            PauseMenuUI.SetActive(true);
        }
        else if (whichMenu == 2)
        {
            ScoreboardUI.SetActive(false);
            ShopUI.SetActive(false);
            soundBtn.SetActive(true);
            healthBar.SetActive(true);
            DeadMenuUI.SetActive(true);

            if (inShop)
            {
                coinImage.transform.position = new Vector3(coinImage.transform.position.x, coinImage.transform.position.y - 170, 0);
                Coins.transform.position = new Vector3(Coins.transform.position.x, Coins.transform.position.y - 170, 0);
                inShop = false;
            }

        }
        alert.SetActive(false);
    }

    public void Continue1()
    {
        tut1.SetActive(false);
        tut2.SetActive(true);
    }

    public void Continue2()
    {
        tut2.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BuyHealth()
    {
        int coins = LoadCoins();

        if(coins >= healthNeededCoins)
        {
            alert.SetActive(false);
            coins -= healthNeededCoins;
            SaveCoins(coins);
            int health = LoadHealth();
            SaveHealth(health+1);
            Player_Movement.coins = coins;
        }
        else
        {
            alert.SetActive(true);
        }

        if (LoadHealth() < 20)
        {
            healthNeededCoins = (LoadHealth() - 2) * 25;
            ShopHealth.text = LoadHealth().ToString();
            coinsValue.text = healthNeededCoins.ToString() + " Coins";
        }
        else
        {
            healthNeededCoins = (LoadHealth() - 2) * 25;
            ShopHealth.text = LoadHealth().ToString();
            coinsValue.text = "MAX";
            buyHealthBtn.SetActive(false);
        }

        Player_Movement.maxHealth = LoadHealth();
    }

    public void BuyMultiplier()
    {
        int coins = LoadCoins();

        if (coins >= multiplierNeededCoins)
        {
            alert.SetActive(false);
            coins -= multiplierNeededCoins;
            SaveCoins(coins);
            int multiplier = LoadMultiplier();
            SaveMultiplier(multiplier + 1);
            Player_Movement.coins = coins;
        }
        else
        {
            alert.SetActive(true);
        }

        if (LoadMultiplier() < 10)
        {
            multiplierNeededCoins = LoadMultiplier() * 500;
            ShopMultiplier.text = "X" + LoadMultiplier().ToString();
            coinsValue2.text = multiplierNeededCoins.ToString() + " Coins";
        }
        else
        {
            multiplierNeededCoins = LoadMultiplier() * 500;
            ShopMultiplier.text = "X" + LoadMultiplier().ToString();
            coinsValue2.text = "MAX";
            buyMultiplierBtn.SetActive(false);
        }
    }

    public void BuyScoreMultiplier()
    {
        int coins = LoadCoins();

        if (coins >= scoreMultiplierNeededCoins)
        {
            alert.SetActive(false);
            coins -= scoreMultiplierNeededCoins;
            SaveCoins(coins);
            int scoreMultiplier = LoadScoreMultiplier();
            SaveScoreMultiplier(scoreMultiplier + 1);
            Player_Movement.coins = coins;
        }
        else
        {
            alert.SetActive(true);
        }

        if (LoadScoreMultiplier() < 10)
        {
            scoreMultiplierNeededCoins = LoadScoreMultiplier() * 1000;
            ShopScoreMultiplier.text = "X" + LoadScoreMultiplier().ToString();
            coinsValue3.text = scoreMultiplierNeededCoins.ToString() + " Coins";
        }
        else
        {
            scoreMultiplierNeededCoins = LoadScoreMultiplier() * 1000;
            ShopScoreMultiplier.text = "X" + LoadScoreMultiplier().ToString();
            coinsValue3.text = "MAX";
            buyScoreMultiplierBtn.SetActive(false);
        }
    }

    void LoadData()
    {
        ScoreData data = new ScoreData(SaveSystem.LoadScore().score);

        scoreArray[0] = data.score[0];
        scoreArray[1] = data.score[1];
        scoreArray[2] = data.score[2];
        scoreArray[3] = data.score[3];
        scoreArray[4] = data.score[4];
    }

    void SaveData()
    {
        int[] info = new int[5];
        info[0] = scoreArray[0];
        info[1] = scoreArray[1];
        info[2] = scoreArray[2];
        info[3] = scoreArray[3];
        info[4] = scoreArray[4];

        SaveSystem.SaveScore(info);
    }

    public int LoadHealth()
    {
        HealthData data = new HealthData(SaveSystem.LoadHealth().health);

        return data.health;
    }

    public void SaveHealth(int info)
    {
        SaveSystem.SaveHealth(info);
    }

    public int LoadCoins()
    {
        CoinsData data = new CoinsData(SaveSystem.LoadCoins().coins);
        return data.coins;
    }

    public void SaveCoins(int info)
    {
        SaveSystem.SaveCoins(info);
    }

    public int Loadtut()
    {
        SeenTutorialData data = new SeenTutorialData(SaveSystem.Loadtut().tut);
        return data.tut;
    }

    public void Savetut(int info)
    {
        SaveSystem.Savetut(info);
    }

    public int LoadMultiplier()
    {
        MultiplierData data = new MultiplierData(SaveSystem.LoadMultiplier().multiplier);

        return data.multiplier;
    }

    public void SaveMultiplier(int info)
    {
        SaveSystem.SaveMultiplier(info);
    }

    public int LoadScoreMultiplier()
    {
        ScoreMultiplierData data = new ScoreMultiplierData(SaveSystem.LoadScoreMultiplier().scoreMultiplier);

        return data.scoreMultiplier;
    }

    public void SaveScoreMultiplier(int info)
    {
        SaveSystem.SaveScoreMultiplier(info);
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
