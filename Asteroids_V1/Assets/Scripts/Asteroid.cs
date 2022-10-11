using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Asteroid : MonoBehaviour
{
    public static Asteroid Instance;

    private Rigidbody2D body;

    public float speed;

    //LISTA PARA LOS RESTOS DE ASTEROIDES
    public GameObject[] subAsteroids;

    //ESTA VARIABLE CONTROLA CUANTOS ASTEROIDES SE GENERARAN
    public int HowManyAsteroids;


    public void Awake()
    {
        Instance = this;
    }

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Bullet"))
        {
            ScoreManager.instance.AddPoint();

            Destroy(gameObject);
            Destroy(collision.gameObject);

        //SE EVALUA SI NO HAY ASTEROIDES EN PANTALLA
            for(var i = 0; i < HowManyAsteroids; i++)
            {
                //SE INSTACIAN LOS ASTEROIDES CORRESPONDIENTES
                Instantiate
                    (
                    //SE ELIGE UN ASTEROIDE AL AZAR
                    subAsteroids[Random.Range(0, subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                    );
            }



        }

        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.scorePoints = 0;
            ScoreManager.instance.score.text = ScoreManager.instance.scorePoints.ToString();
            var asteroids = FindObjectsOfType<Asteroid>();
            for (var i = 0; i < asteroids.Length; i++)
            {
                Destroy(asteroids[i].gameObject);
            }
            ScoreManager.instance.scorePoints = 0;
            collision.GetComponent<Ship>().Lose();
        }


    }

}
