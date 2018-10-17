using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {

    Material material;
    Vector2 offset;

	// Use this for initialization
	void Start () {

        material = GetComponent<Renderer>().material;
        offset = new Vector2(0, MainCamera.posY);

	}
	
	// Update is called once per frame
	void Update () {


        material.mainTextureOffset += offset;
        

	}
}
