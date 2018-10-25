using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    
    public float speed = 6f;
    public float jumpPower = 6f;
    public bool grounded;
    public int lifes = 3;
    public static bool isDead = false;




    private Rigidbody2D rb2d;
    private Animator anim;


    // Use this for initialization
    void Start () {
        
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {



        float horizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

        if (lifes <= 0)
        {
            isDead = true;
            Debug.Log("Killed");
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
            transform.position = new Vector3(10.5f, transform.position.y+1f, transform.position.z);
        }
        else if (transform.position.x >= 11f)
        {
            transform.position = new Vector3(-10.5f, transform.position.y+1f, transform.position.z);
        }

        anim.SetFloat("SpeedY", rb2d.velocity.y);

        if (transform.position.y <= MainCamera.posY - 10f)
        {
            Die();
        }
        if (MainMenu.revive == true)
        {
            isDead = false;
            gameObject.SetActive(true);
            MainMenu.revive = false;
        }

    }




    void Die()
    {
            isDead = true;
            gameObject.SetActive(false);
            Debug.Log("Moñeco");
    }
}
