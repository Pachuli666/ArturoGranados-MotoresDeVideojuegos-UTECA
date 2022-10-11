using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    
    //ESTAMOS PULSANDO EL EJE VERTICAL
    public static float Vertical
    {
        get { return Input.GetAxis("Vertical"); }
    }

    //ESTAMOS PULSANDO EL EJE HORIZONTAL
    public static float Horizontal
    {
        get { return Input.GetAxis("Horizontal"); }
    }

    //ESTAMOS PULSANDO LA BARRA ESPACIADORA
    public static bool Fire
    {
        get { return Input.GetKey(KeyCode.Space); }
    }

 }
