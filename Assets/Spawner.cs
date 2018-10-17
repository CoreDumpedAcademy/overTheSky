﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject[] obj;
    public float tiempoMin = 1.25f;
    public float tiempoMax = 2.5f;

    Vector3 pos;
    private float x, y, z;
    public GameObject cam;

    // Use this for initialization
    void Start()
    {
        
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

        x = Random.Range(-9.41f, 9.22f);
        y = Random.Range(cam.transform.position.y -1f, cam.transform.position.y + 1f);
        z = 0;

        pos = new Vector3(x, y, z);

        transform.position = pos;

        Debug.Log(transform.position.y);
        //Debug.Log(pos);

    }

    void Spawn()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(tiempoMin, tiempoMax));
    }
}
