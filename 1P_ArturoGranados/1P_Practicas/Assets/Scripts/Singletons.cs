using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons instance;


    public int Contador = 0;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        Contador++;
    }

}
