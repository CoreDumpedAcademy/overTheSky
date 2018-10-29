using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicEnemy : MonoBehaviour
{
    public static bool killActive;
    public float killActiveTime = 3f;
    public static float damage = 1;

    private float timer;

    private SpriteRenderer spriteRend;
    private Animator anim;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        timer = killActiveTime;
        if (Random.Range(0f, 10f) >= 5)
        {
            killActive = true;
            anim.SetTrigger("Spikes");
        }
        else
        {
            killActive = false;
        }
    }


    void Update()
    {
        Timer();
        if (transform.position.y <= MainCamera.posY - 10)
        {
            Destroy(gameObject);
        }

    }

    void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            killActive = !killActive;
            if (killActive)
            {
                anim.SetTrigger("Spikes");
            }
            else
            {
                anim.SetTrigger("Idle");
            }
            timer = killActiveTime;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        
    }
}
