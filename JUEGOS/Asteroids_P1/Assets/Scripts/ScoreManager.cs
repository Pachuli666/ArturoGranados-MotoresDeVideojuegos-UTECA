using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    //SCORE VALUES

    public TMP_Text score;

    public TMP_Text highScore;

    public int scorePoints;

    public int HighScorePoints = 0;

    public void Awake()
    {
    
    scorePoints = 0;

    instance = this;

    }
    void Start()
    {
        HighScorePoints = PlayerPrefs.GetInt("HighScorePoints", 0);
        score.text = scorePoints.ToString();
        highScore.text = HighScorePoints.ToString();
    }
    
    public void AddPoint()
    {
        scorePoints+=1;
        score.text = scorePoints.ToString();

        if(HighScorePoints < scorePoints)
        
            PlayerPrefs.SetInt("HighScorePoints", scorePoints);
        
        
    }
}
