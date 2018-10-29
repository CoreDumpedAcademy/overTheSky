using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {


    

    public static int scoreV1;
    public static int scoreV2;
    public static int scoreV3;
    public static int scoreV4;
    public static int scoreV5;

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

        

        Score1.score1.text = "" + scoreV1;
        Score2.score2.text = "" + scoreV2;
        Score3.score3.text = "" + scoreV3;
        Score4.score4.text = "" + scoreV4;
        Score5.score5.text = "" + scoreV5;

    }

    
}
