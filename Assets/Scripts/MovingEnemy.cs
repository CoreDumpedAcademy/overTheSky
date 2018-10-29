using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{

    public static bool killActive = true;
    public float enemyVelocity = 0.1f;
    public static float damage = 1.5f;
    private float counter=3f;

    private int xDir;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    private Animator anim;
    private SpriteRenderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        CalcuateNewMovementVector();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(movementPerSecond);
        if (transform.position.x <= -10f || transform.position.x >= 10f)
        {
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            }
            SwitchVector();
        }

        if (transform.position.y <= MainCamera.posY - 10)
        {
            Destroy(gameObject);
        }
    }

    void SwitchVector()
    {
        movementPerSecond = -movementPerSecond;
        xDir = -xDir;
        transform.localScale = new Vector3(xDir * 4f, 4f, 1f);
    }

    void CalcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        xDir = Random.Range(-1, 1) > 0 ? 1 : -1;
        transform.localScale = new Vector3(xDir * 4f, 4f, 1f);
        movementDirection = new Vector2(xDir, 0).normalized;
        movementPerSecond = movementDirection * enemyVelocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enviroment" || col.gameObject.tag == "Floor")
        {

            if (transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            }

            SwitchVector();


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
                    transform.position = new Vector3(transform.position.x + 4f, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x - 4f, transform.position.y, transform.position.z);
                }
                counter = 3f;
            }
            SwitchVector();


        }
    }

}
