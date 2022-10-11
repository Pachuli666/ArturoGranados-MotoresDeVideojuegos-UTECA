using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SE DECLARAN FUERA LOS TRES TIPOS DE FASES EN EL JUEGO
public enum GameState
{
    Menu,
    Play,
    GameOver
}

public class GameManager : MonoBehaviour
{

    //PUNTO DE ACCESO PARA TODA LA ESCENA
    public static GameManager sharedInstance;

    //SE INICIALIZA DESDE LA PRIMERA FASE
    public GameState GamePhase = GameState.Menu;

    public Canvas MenuCanvas;

    public Canvas GameCanvas;

    public Canvas GameOverCanvas;

    public int Points = 0;


    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        GamePhase = GameState.Menu;

        //HABILITANDO UNICAMENTE EL MENU PRINCIPAL
        MenuCanvas.enabled = true;
        GameCanvas.enabled = false;
        GameOverCanvas.enabled = false;
    }


    //EMPIEZA EL JUEGO
    public void StartGame()
    {

        //SE CORRE EL METODO QUE CONFIGURA AL PERSONAJE EN SU POSICION INICIAL
        Ship.Instance.Start();

        Asteroid.Instance.Start();

        ChangeGamePhase(GameState.Play);

        //CARGAMOS LA PUNTUACION MAXIMA DESDE EL SCRIPT GAME VIEW
        GameView.sharedinstance.UpdateHighScore();
    }

    //SE ACABA EL JUEGO 
    public void GameOver()
    {
        GameOverCanvas.enabled = true;
        
        ChangeGamePhase(GameState.GameOver);

    }

    //VAMOS AL MENU
    public void GoToMainMenu()
    {
        ChangeGamePhase(GameState.Menu);
    }


    //ESTE METODO NECESITA UN ESTADO DEL JUEGO PARA FUNCIONAR
    void ChangeGamePhase(GameState newGamePhase)
    {
        //SHOW ME THE MENU
        if (newGamePhase == GameState.Menu)
        {
            //ACTIVAMOS LOS CANVAS QUE CORRESPONDEN AL ESTADO DEL JUEGO
            MenuCanvas.enabled = true;
            GameCanvas.enabled = false;
            GameOverCanvas.enabled = false;
        }
        //SHOW ME THE GAME
        else if (newGamePhase == GameState.Play)
        {
            MenuCanvas.enabled = false;
            GameCanvas.enabled = true;
            GameOverCanvas.enabled = false;
        }
        //SHOW ME THE GAME OVER SCREEN
        else if (GamePhase == GameState.GameOver)
        {
            MenuCanvas.enabled = false;
            GameCanvas.enabled = false;
            GameOverCanvas.enabled = true;
        }
        //AL TERMINAR DE EVALUAR LA FASE SE DETERMINA CUAL ES EL ESTADO DEL JUEGO EN CURSO
        GamePhase = newGamePhase;
    }

    public void HowManyPoints()
    {
        //SE IRAN SUMANDO CADA VEZ QUE SE INVOQUE ESTE METODO

        Points++;

        //LLAMAMOS EL METODO DE GAME VIEW PARA MANIPULAR EL CONTADOR DE MONEDAS
        GameView.sharedinstance.UpdatePoints();

    }
}


