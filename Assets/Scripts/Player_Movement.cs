using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System;
using UnityEngine.UI;
using TMPro;

public class Player_Movement : MonoBehaviour
{


    public float speed = 6f;
    public float jumpPower = 6f;
    public bool grounded;
    public static float maxHealth;
    private float health;
    public static bool isDead;
    public static int scoreValue;
    public static int realScoreValue;
    public static int coins;
    private int heigthDetect;
    public static bool toAddScore=false;
    public static float timer = 3f;
    public static bool addScore;
    private float actualHealth = 0;
    private float ScreenWidth;
    private bool kiss;
    public GameObject LifeCount;
    private TextMeshProUGUI lifeCount;

    Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spriteRend;
    public GameObject healthBar;

    private float animCounter;

    public ParticleSystem part1;
    public ParticleSystem part2;

    private int scoreMultiplier;

    // Use this for initialization
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scoreValue = (int)transform.position.y + 3;
        health = LoadHealth();
        ScreenWidth = Screen.width;
        maxHealth = LoadHealth();
        coins = LoadCoins();
        lifeCount = LifeCount.GetComponent<TextMeshProUGUI>();
        scoreMultiplier = LoadScoreMultiplier();

        animCounter = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health >= 0)
        {
            lifeCount.text = health.ToString();
        }
        else
        {
            lifeCount.text = "0";
        }
        

        #if UNITY_EDITOR
        RunCharacter(Input.GetAxis("Horizontal"));
        #endif

        animCounter -= Time.deltaTime;

        if (animCounter  <= 0)
        {
            anim.SetFloat("SpeedY", 1);
            part1.Play();
            part2.Play();
            animCounter = 0.8f;
        }
        else
        {
            anim.SetFloat("SpeedY", -1);
        }

        

        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //move right
                RunCharacter(1.0f);
                transform.localScale = new Vector3(3f, 3f, 3f);
            }
            else if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left
                RunCharacter(-1.0f);
                transform.localScale = new Vector3(-3f, 3f, 3f);
            }

            if (Input.GetTouch(i).phase == TouchPhase.Canceled || Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                RunCharacter(0f);
            }
            ++i;
        }

        

        actualHealth = health / maxHealth;
        
        if(health >= 0)
        {
            healthBar.transform.localScale = new Vector3(actualHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
        else
        {
            healthBar.transform.localScale = new Vector3(0, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
        

        if (health <= 0)
        {
            Die();
            health = LoadHealth();
        }

        if (grounded == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }

        if (transform.position.x <= -11f)
        {
            transform.position = new Vector3(10.5f, transform.position.y + 1f, transform.position.z);
        }
        else if (transform.position.x >= 11f)
        {
            transform.position = new Vector3(-10.5f, transform.position.y + 1f, transform.position.z);
        }

        if (transform.position.y <= MainCamera.posY - 8f)
        {
            Die();
        }

        if (transform.position.y >= 0)
        {
            
            if (PauseMenu.scoreText < (transform.position.y * scoreMultiplier))
            {
                scoreValue = (int)(transform.position.y * scoreMultiplier);
            }
            

        }

    }

    void Die()
    {
        SaveCoins(coins);
        Array.Sort(PauseMenu.scoreArray);
        Array.Reverse(PauseMenu.scoreArray);

        Debug.Log(PauseMenu.scoreArray);
        if (scoreValue > PauseMenu.scoreArray[4])
        {
            PauseMenu.scoreArray[4] = scoreValue;
            Array.Sort(PauseMenu.scoreArray);
            Array.Reverse(PauseMenu.scoreArray);
            Debug.Log(PauseMenu.scoreArray[4]);

        }
        toAddScore = true;
        addScore = true;
        isDead = true;
        gameObject.SetActive(false);
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && col.gameObject.GetComponent<Animator>().GetBool("Spikes"))
        {
            anim.SetTrigger("PlayerDamaged");
            health -= BasicEnemy.damage;
        }

        if (col.gameObject.tag == "FlyingEnemy")
        {
            anim.SetTrigger("PlayerDamaged");
            health -= MovingEnemy.damage;

        }
    }

    private void RunCharacter(float horizontal)
    {
        //move player
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

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
        Debug.Log(data);
        return data.coins;
    }

    public void SaveCoins(int info)
    {
        SaveSystem.SaveCoins(info);
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

}
