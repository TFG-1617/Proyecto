using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFinal : MonoBehaviour {

    GameObject scoreFinalGO;
    Text scoreFinalText;
    int score;
    

    // Use this for initialization
    void Start () {
        scoreFinalGO = GameObject.Find("ScoreText");
        scoreFinalText = scoreFinalGO.GetComponent<Text>();
        score = PlayerPrefs.GetInt("LastScore");

        scoreFinalText.text = score.ToString();

        /* Save score total */
        SaveTotalScore();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SaveTotalScore()
    {
        int totalScore = PlayerPrefs.GetInt("TotalScore");
        PlayerPrefs.SetInt("TotalScore", totalScore + score);
    }
}
