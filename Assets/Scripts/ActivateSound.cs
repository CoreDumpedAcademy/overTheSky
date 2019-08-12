using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSound : MonoBehaviour
{
    private AudioSource music;
    private int playing;

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        playing = PlayerPrefs.GetInt("soundPlay");
        if(playing == 1)
        {
            music.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
