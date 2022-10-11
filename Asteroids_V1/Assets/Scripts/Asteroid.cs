using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    public static Asteroid Instance;

    public int points = 0;

    private Rigidbody2D body;

    public float speed;

    //LISTA PARA LOS RESTOS DE ASTEROIDES
    public GameObject[] subAsteroids;

    public int HowManyAsteroids;

    public bool isDestroying = false;
    public void Start()
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDestroying)
        {
            return;
        }


        if (collision.CompareTag("Bullet"))
        {
            GameManager.sharedInstance.HowManyPoints();
            Destroy(gameObject);
            Destroy(collision.gameObject);

        //SE EVALUA SI NO HAY ASTEROIDES EN PANTALLA
            for(var i = 0; i < HowManyAsteroids; i++)
            {
                //SE INSTACIAN LOS ASTEROIDES CORRESPONDIENTES
                Instantiate
                
                    (

                    //SE ELIGE UN ASTEROIDE AL AZAR
                    subAsteroids[Random.Range(0,subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity

                    );

            }
            
        }
    }

}
