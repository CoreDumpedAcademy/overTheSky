using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    
    public float speed = 6f;
    public float jumpPower = 6f;
    public bool grounded;
    

    

    private Rigidbody2D rb2d;
    

    // Use this for initialization
    void Start () {
        
        rb2d = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(grounded);

        float horizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (grounded == true)
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);

        }
        
        if (horizontal > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        
    }

     

}
