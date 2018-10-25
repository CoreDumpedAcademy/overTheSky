using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {

    public static bool killActive = true;
    public float enemyVelocity = 0.1f;
    public static float damage = 1.5f;

    private int xDir;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    private Animator anim;
    private SpriteRenderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        CalcuateNewMovementVector();
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(movementPerSecond);
        if (transform.position.x <= -10f || transform.position.x >= 10f)
            SwitchVector();
        if (transform.position.y <= MainCamera.posY - 10)
        {
            Destroy(gameObject);
        }
    }

    void SwitchVector () {
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
        if (col.gameObject.tag == "Enviroment")
        {
            SwitchVector();
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        float timer = 3f;
        timer = timer - Time.deltaTime;

        if (timer <= 0 && col.gameObject.tag == "Enviroment")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        }
    }
}
