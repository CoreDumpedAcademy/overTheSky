using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {




    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;

    public static int scoreCount;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {

        score1.text = "" + PauseMenu.scoreArray[0];
        score2.text = "" + PauseMenu.scoreArray[1];
        score3.text = "" + PauseMenu.scoreArray[2];
        score4.text = "" + PauseMenu.scoreArray[3];
        score5.text = "" + PauseMenu.scoreArray[4];

    }

    
}
