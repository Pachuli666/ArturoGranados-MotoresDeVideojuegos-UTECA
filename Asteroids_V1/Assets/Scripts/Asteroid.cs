using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D body;

    public float speed;

    void Start()
    {
        //Referenciamos la variable con el RigidBody del GameObject

        body = GetComponent<Rigidbody2D>();

        //No queremos que se detenga
        body.drag = 0;

        //No queremos que deje de rotar
        body.angularDrag = 0;


        //Velocidad aleatoria en todos los ejes excepto Z
        body.velocity = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0
            //Velocidad constante
            ).normalized * speed;

        //Velocidad de rotacion
        body.angularVelocity = Random.Range(-50f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
