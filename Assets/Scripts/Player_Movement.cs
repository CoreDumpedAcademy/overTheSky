using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{


    public float speed = 6f;
    public float jumpPower = 6f;
    public bool grounded;
    public float lifes = 3f;
    public static bool isDead;
    public static int scoreValue;
    private int heigthDetect;
    public static int scores;
    public static bool toAddScore=false;
    public static float timer = 3f;



    Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spriteRend;

    // Use this for initialization
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scoreValue = (int)transform.position.y + 3;

    }

    // Update is called once per frame
    void Update()
    {

        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            BasicEnemy.killActive = !BasicEnemy.killActive;
            timer = 3f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

        if (lifes <= 0)
        {
            Die();
            
            Debug.Log("Killed");
            lifes = 10;
        }
        if (grounded == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }


        if (horizontal > 0.1f)
        {
            transform.localScale = new Vector3(3f, 3f, 3f);
        }

        if (horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-3f, 3f, 3f);
        }

        if (transform.position.x <= -11f)
        {
            transform.position = new Vector3(10.5f, transform.position.y + 1f, transform.position.z);
        }
        else if (transform.position.x >= 11f)
        {
            transform.position = new Vector3(-10.5f, transform.position.y + 1f, transform.position.z);
        }

        anim.SetFloat("SpeedY", rb2d.velocity.y);

        if (transform.position.y <= MainCamera.posY - 8f)
        {
            Die();
        }

        if (transform.position.y >= 0)
        {
            
            if (PauseMenu.scoreText < transform.position.y)
            {
                scoreValue = (int)transform.position.y;
            }
            

        }

    }

    void Die()
    {
        scores = scoreValue;
        toAddScore = true;
        isDead = true;
        PauseMenu.addScore = true;
        gameObject.SetActive(false);
        Debug.Log("Moñeco");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && BasicEnemy.killActive)
        {
            anim.SetTrigger("PlayerDamaged");
            lifes -= BasicEnemy.damage;
        }
        if (col.gameObject.tag == "FlyingEnemy")
        {
            anim.SetTrigger("PlayerDamaged");
            lifes -= MovingEnemy.damage;

        }
    }
}
