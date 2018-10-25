using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckGround : MonoBehaviour {

    private Player_Movement player;

	// Use this for initialization
	void Start () {

        player = GetComponentInParent<Player_Movement>();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (BasicEnemy.killActive == true)
            {
                player.lifes -= BasicEnemy.damage;
            }
            player.grounded = true;

        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        player.grounded |= col.gameObject.tag == "Floor";
        player.grounded &= col.gameObject.tag != "FlyingEnemy";
    }

     void OnCollisionExit2D(Collision2D col)
    {
        player.grounded &= (col.gameObject.tag != "Floor" && col.gameObject.tag != "Enemy" && col.gameObject.tag != "FlyingEnemy" );

        
    }

   


}
