using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBlocking : MonoBehaviour {


    public static Transform trs;

    

	// Use this for initialization
	void Start () {

        trs = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

        

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enviroment" || col.gameObject.tag == "Floor")
        {
            if (transform.position.x <= 0)
            {
                transform.position = new Vector3(transform.position.x + 4f, transform.position.y, transform.position.z);
                Debug.Log(transform.position.x);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 4f, transform.position.y, transform.position.z);
            }
            Debug.Log("hola");
        }
    }
}
