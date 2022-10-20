using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonInstance : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    
    {
        Debug.Log("Este es el contador del otro codigo " + Singletons.instance.Contador);
    }
}
