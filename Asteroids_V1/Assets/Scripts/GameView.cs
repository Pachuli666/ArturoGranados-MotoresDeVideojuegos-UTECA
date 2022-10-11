using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameView : MonoBehaviour
{
    public static GameView sharedinstance;

    public TMP_Text AsteroidPoints;
    public TMP_Text HighScore;

    private void Awake()
    {
        sharedinstance = this;
    }

    public void UpdateHighScore()
    {
        if (GameManager.sharedInstance.GamePhase == GameState.Play)
        {
            //DE IGUAL MANERA LA PUNTUACION MAXIMAN DEPENDERA DE LA DISTANCIA RECORRIDA 
            HighScore.text = PlayerPrefs.GetFloat("highScore", 0).ToString("f0");
        }
    }

    public void UpdatePoints()
    {
        //SI LA FASE DEL JUEGO ES IGUAL A PLAY
        if (GameManager.sharedInstance.GamePhase == GameState.Play)
        {
            //LOS DATOS DE UpdatePoints dependeran de la variable Points del GameManager
            AsteroidPoints.text = GameManager.sharedInstance.Points.ToString();
        }
    }
}

