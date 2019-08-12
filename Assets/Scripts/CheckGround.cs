using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckGround : MonoBehaviour {

    private Player_Movement player;
    private int multiplier;
    

	// Use this for initialization
	void Start () {

        player = GetComponentInParent<Player_Movement>();
        multiplier = LoadMultiplier();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            player.grounded = true;
        }
        if (col.gameObject.tag == "FlyingEnemy")
        {
            player.grounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        float timer = 3f;
        timer = timer - Time.deltaTime;
        if (timer <= 0 && col.gameObject.tag == "Enviroment")
        {      
            
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
            timer = 3f;
        }
        
        player.grounded |= col.gameObject.tag == "Floor";
        player.grounded &= col.gameObject.tag != "FlyingEnemy";
    }

     void OnCollisionExit2D(Collision2D col)
    {
        player.grounded &= (col.gameObject.tag != "Floor" && col.gameObject.tag != "Enemy" && col.gameObject.tag != "FlyingEnemy" );

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Player_Movement.coins = Player_Movement.coins + multiplier;
        }
    }

    public int LoadMultiplier()
    {
        MultiplierData data = new MultiplierData(SaveSystem.LoadMultiplier().multiplier);

        return data.multiplier;
    }


}
