using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{

    public static bool killActive = true;
    public float speed = 0;
    public static float damage = 1.5f;
    public float orientation = 1;
    private float counter = 0.1f;
   
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    private Animator anim;
    private SpriteRenderer rend;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        counter = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= MainCamera.posY - 10)
        {
            Destroy(gameObject);
        }

        rb.velocity = new Vector2(orientation * speed, rb.velocity.y);

        if (orientation > 0.1f)
        {
            transform.localScale = new Vector3(5f, 5f, 1f);
        }

        if (orientation < -0.1f)
        {
            transform.localScale = new Vector3(-5f, 5f, 1f);
        }

        if (transform.position.x <= -10f || transform.position.x >= 10f)
        {

            if (orientation > 0)
            {
                transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
                orientation = -1;
            }
            else if (orientation < 0)
            {
                transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
                orientation = 1;
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enviroment" || col.gameObject.tag == "Floor")
        {
            if (orientation > 0)
            {              
                orientation = -1;
            }
            else if (orientation < 0)
            {                
                orientation = 1;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enviroment" || col.gameObject.tag == "Floor")
        {
            counter = counter - Time.deltaTime;
            if (counter <= 0)
            {
                if (transform.position.x < 0)
                {
                    transform.position = new Vector3(0, transform.position.y + 1f, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(0, transform.position.y + 1f, transform.position.z);
                }
                counter = 0.1f;
            }


        }
        else
        {
            counter = 0.1f;
        }
    }
}
