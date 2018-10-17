using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public GameObject follow;
    public Vector2 maxCamPos;
    public Vector2 minCamPos;


    public float smoothTime;
    public float counter = 5f;
    private Vector2 velocity;
    public float posX, posY;

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
         posX = Mathf.SmoothDamp(transform.position.x,
            follow.transform.position.x, ref velocity.x, smoothTime);
         posY = Mathf.SmoothDamp(transform.position.y,
            follow.transform.position.y, ref velocity.y, smoothTime);

        counter -= Time.deltaTime;

        if (posY >= minCamPos.y)
        {

            minCamPos.y = minCamPos.y + 0.05f;
            counter = 0.0000025f;
            

        }
        else
        {
            
            if (counter < 0)
            {
                minCamPos.y = minCamPos.y + 0.01f;
                counter = 0.025f;
                
            }
        }

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z);
    }

}
