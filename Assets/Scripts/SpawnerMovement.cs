using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour {


    public float counter1 = 0f;
    public float camSpeed = 0.5f;

    // Use this for initialization
    void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {

        counter1 -= Time.deltaTime;

        if (counter1 < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * camSpeed);
            counter1 = 0.025f;

        }

    }
}
