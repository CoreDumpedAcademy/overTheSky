using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicEnemy : MonoBehaviour
{
    private bool killActive = false;
    public float killActiveTime = 3f;
    public static float damage = 1;

    private float timer;

    private SpriteRenderer spriteRend;
    private Animator anim;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (transform.position.y <= MainCamera.posY - 10)
        {
            Destroy(gameObject);
        }

        killActiveTime = killActiveTime - Time.deltaTime;
        if (killActiveTime <= 0)
        {
            if (killActive)
            {
                anim.SetBool("Spikes", false);              
            }
            else
            {
                anim.SetBool("Spikes", true);               
            }
            killActive = !killActive;
            killActiveTime = 3f;
        }

        if (killActive)
        {
            spriteRend.color = Color.red;
        }
        else
        {
            spriteRend.color = Color.white;
        }

    }

}
