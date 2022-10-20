using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //Este formato hace visible la informacion en el inspector

    [System.Serializable]
  
    //Con la variable struct creamos una grupo de parametros que compartiran el mismo tipo de variable,
    //en este caso una variable tipo float que contiene cuatro valores diferentes.
    public struct Borders
  { 

    public float TopBorder, BottomBorder, LeftBorder, RightBorder;

  }  

    public class Limits : MonoBehaviour
{

    public Borders border;

    void Update()
    {
        //El uso de "var" es un atajo para no escribir el tipo de variable al inicio, de esta manera solo lo demostramos al final.

        var pos = transform.position;
        var ship_x = transform.position.x;
        var ship_y = transform.position.y;

        //La posicion de la nave se comparara con los limites establecidos.
        //Si el jugador supera los limites es transportado al lado opuesto de la pantalla.

        if( ship_x > border.RightBorder)
        {
            pos.x = border.LeftBorder;
            transform.position = pos;
        }

        if (ship_x < border.LeftBorder)
        {
            pos.x = border.RightBorder;
            transform.position = pos;
        }

        if ( ship_y > border.TopBorder)
        {
            pos.y = border.BottomBorder;
            transform.position = pos;
        }

        if (ship_y < border.BottomBorder)
        {
            pos.y = border.TopBorder;
            transform.position = pos;
        }

    }
}



