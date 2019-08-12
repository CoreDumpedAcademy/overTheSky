using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBtn : MonoBehaviour
{

    private AudioSource music;
    public Button self;
    private Image actualSprite;

    public Sprite Sound;
    public Sprite NotSound;

    private int playing;
    private float count;

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Button>();
        actualSprite = GetComponent<Image>();
        count = 3f;
        music = GameObject.FindGameObjectWithTag("MainMenuMusic").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;

        if(count > 0)
        {
            playing = PlayerPrefs.GetInt("soundPlay");
            if (playing == 1)
            {
                actualSprite.sprite = NotSound;
                music.Pause();
            }
        }

        if(count <= -20)
        {
            count = -18;
        }
        
    }

    public void PauseMusic()
    {
        if (music.isPlaying)
        {
            music.Pause();
            PlayerPrefs.SetInt("soundPlay", 1);
            self.interactable = true;
            actualSprite.sprite = NotSound;
        }
        else
        {
            music.Play();
            PlayerPrefs.SetInt("soundPlay", 0);
            self.interactable = true;
            actualSprite.sprite = Sound;
        }       
    }
}
