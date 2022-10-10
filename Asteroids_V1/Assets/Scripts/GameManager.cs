using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Score;

    public int Puntos;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SumarPuntos();
            Score.text = Puntos.ToString();
        }

    }

    public void SumarPuntos()
    {
        Puntos++;
    }
}
