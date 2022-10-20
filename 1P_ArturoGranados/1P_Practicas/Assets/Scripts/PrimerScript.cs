using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    //LAS VARIABLES DE TIPO FLOAT SON PARA GUARDAR NUMERO DECIMALES
    public float speed;

    //LAS VARIABLES DE TIPO INT SON PARA GUARDAR NUMEROS ENTEROS
    public int position;

    //LAS VARIABLES DE TIPO RIGIDBODY SON UNA REFERENCIA PARA MODIFICAR FISICAMENTE AL OBJETO
    public Rigidbody2D body;

    public void Awake()
    {
        
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        position++;
        Move();
    }

    //LOS METODOS SON BLOQUES DE INSTRUCCIONES
    public void Move()
    {
        Debug.Log(position);


        body.velocity = transform.right * speed * Time.deltaTime;
            
        
    }
}
