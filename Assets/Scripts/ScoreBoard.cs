using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {


    

    public int scoreV1;
    public int scoreV2;
    public int scoreV3;
    public int scoreV4;
    public int scoreV5;

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

        if(Player_Movement.toAddScore == true)
        {
            PauseMenu.addScore = true;
            Player_Movement.toAddScore = false;
        }

        scoreV1 = PlayerPrefs.GetInt("Score1", 0);
        scoreV2 = PlayerPrefs.GetInt("Score2", 0);
        scoreV3 = PlayerPrefs.GetInt("Score3", 0);
        scoreV4 = PlayerPrefs.GetInt("Score4", 0);
        scoreV5 = PlayerPrefs.GetInt("Score5", 0);

        if (PauseMenu.addScore == true)
        {
            scoreCount = PlayerPrefs.GetInt("scoreCount", 0);
            
            
            switch (scoreCount)
            {
                case 0:
                    PlayerPrefs.SetInt("Score1", Player_Movement.scores);
                    
                    break;

                case 1:

                    if (Player_Movement.scores >= scoreV1)
                    {
                        PlayerPrefs.SetInt("Score2", scoreV1);
                        PlayerPrefs.SetInt("Score1", Player_Movement.scores);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Score2", Player_Movement.scores);
                        
                    }

                    break;

                case 2:

                    if (Player_Movement.scores >= scoreV1)
                    {
                        
                            PlayerPrefs.SetInt("Score3", scoreV2);
                            PlayerPrefs.SetInt("Score2", scoreV1);
                            PlayerPrefs.SetInt("Score1", Player_Movement.scores);
                        
                    }
                    else if (Player_Movement.scores < scoreV1 && Player_Movement.scores >= scoreV1)
                    {

                        PlayerPrefs.SetInt("Score3", scoreV2);
                        PlayerPrefs.SetInt("Score2", Player_Movement.scores);

                    }
                    else if (Player_Movement.scores < scoreV1 && Player_Movement.scores < scoreV1)
                    {
                        PlayerPrefs.SetInt("Score3", Player_Movement.scores);
                    }

                    break;

                case 3:

                    if (Player_Movement.scores >= scoreV1)
                    {

                        PlayerPrefs.SetInt("Score4", scoreV3);
                        PlayerPrefs.SetInt("Score3", scoreV2);
                        PlayerPrefs.SetInt("Score2", scoreV1);
                        PlayerPrefs.SetInt("Score1", Player_Movement.scores);

                    }
                    else if (Player_Movement.scores < scoreV1 && Player_Movement.scores >= scoreV2)
                    {
                        PlayerPrefs.SetInt("Score4", scoreV3);
                        PlayerPrefs.SetInt("Score3", scoreV2);
                        PlayerPrefs.SetInt("Score2", Player_Movement.scores);

                    }
                    else if (Player_Movement.scores < scoreV1 && Player_Movement.scores < scoreV2 && Player_Movement.scores >= scoreV3)
                    {
                        PlayerPrefs.SetInt("Score4", scoreV3);
                        PlayerPrefs.SetInt("Score3", Player_Movement.scores);

                    }else if (Player_Movement.scores < scoreV1 && Player_Movement.scores < scoreV2 && Player_Movement.scores < scoreV3)
                    {
                        PlayerPrefs.SetInt("Score4", Player_Movement.scores);
                    }

                    
                    

                    break;

                case 4:

                    if (Player_Movement.scores >= scoreV1)
                    {

                        PlayerPrefs.SetInt("Score5", scoreV4);
                        PlayerPrefs.SetInt("Score4", scoreV3);
                        PlayerPrefs.SetInt("Score3", scoreV2);
                        PlayerPrefs.SetInt("Score2", scoreV1);
                        PlayerPrefs.SetInt("Score1", Player_Movement.scores);

                    }
                    else if (Player_Movement.scores < scoreV1 && Player_Movement.scores >= scoreV1)
                    {

                        PlayerPrefs.SetInt("Score5", scoreV4);
                        PlayerPrefs.SetInt("Score4", scoreV3);
                        PlayerPrefs.SetInt("Score3", scoreV2);
                        PlayerPrefs.SetInt("Score2", Player_Movement.scores);

                    }
                    else if (Player_Movement.scores < scoreV1 && Player_Movement.scores < scoreV2 && Player_Movement.scores >= scoreV3)
                    {
                        PlayerPrefs.SetInt("Score5", scoreV4);
                        PlayerPrefs.SetInt("Score4", scoreV3);
                        PlayerPrefs.SetInt("Score3", Player_Movement.scores);

                    }
                    else if (Player_Movement.scores < scoreV1 && Player_Movement.scores < scoreV2 && Player_Movement.scores < scoreV3 && Player_Movement.scores >= scoreV4)
                    {
                        PlayerPrefs.SetInt("Score5", scoreV4);
                        PlayerPrefs.SetInt("Score4", Player_Movement.scores);
                    }else if (Player_Movement.scores < scoreV1 && Player_Movement.scores < scoreV2 && Player_Movement.scores < scoreV3 && Player_Movement.scores < scoreV4 && Player_Movement.scores > scoreV5)
                    {
                        PlayerPrefs.SetInt("Score5", Player_Movement.scores);
                    }else if (Player_Movement.scores < scoreV1 && Player_Movement.scores < scoreV2 && Player_Movement.scores < scoreV3 && Player_Movement.scores < scoreV4 && Player_Movement.scores < scoreV5)
                    {

                    }


                    scoreCount = 3;
                    break;

            }
            scoreCount = scoreCount + 1;
            PlayerPrefs.SetInt("scoreCount", scoreCount);

            Debug.Log("Ayer");

            scoreV1 = PlayerPrefs.GetInt("Score1", 0);
            scoreV2 = PlayerPrefs.GetInt("Score2", 0);
            scoreV3 = PlayerPrefs.GetInt("Score3", 0);
            scoreV4 = PlayerPrefs.GetInt("Score4", 0);
            scoreV5 = PlayerPrefs.GetInt("Score5", 0);

            PauseMenu.addScore = false;
        }

        Score1.score1.text = "" + scoreV1;
        Score2.score2.text = "" + scoreV2;
        Score3.score3.text = "" + scoreV3;
        Score4.score4.text = "" + scoreV4;
        Score5.score5.text = "" + scoreV5;

    }

    
}
