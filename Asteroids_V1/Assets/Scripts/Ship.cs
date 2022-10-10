using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    //SINGLETON
    public static Ship door;

    private Rigidbody2D shipBody;

    private float vertical;

    private float horizontal;

    private bool shooting;

    public float speed;

    //ES NECESARIO PONER LIMITES DE ACELERACION PARA QUE LA NAVE PUEDA MANIPULARSE FACILMENTE
    public float maxSpeed;

    //VARIABLE PARA DETENER LA NAVES SI NO PRESIONAMOS EL ACELERADOR
    public float brake;

    //VATIABLE PARA QUE LA NAVE GIRE
    public float angularSpeed;

    //BULLETS

    public float bulletPosition;

    public GameObject bulletPrefab;

    public bool CanShoot = false;

    private float ShootTime = 0.35f;

    private void Awake()
    {
        if(door != null)
        {
            return;
        }

        door = this;
    }

    void Start()
    {
        //LE INDICAMOS QUE SELECCIONA EL RIGIDBODY DEL GAMEOBJECT
        shipBody = GetComponent<Rigidbody2D>();
        
        //LA PROPIEDAD DRAG SIRVE DE FRENO DE MANO PARA DETENER UN OBJETO, LA INTENSIDAD DEPENDERA DE NOSOTROS
        //AL ASIGNARLE UN VALOR A LA VARIABLE QUE LO MODIFICARA
        // EN OTRAS PALABRAS LE ASIGNARA UN VELOCIDAD CONSTANTE
        shipBody.drag = brake;
    }

    // Update is called once per frame
    void Update()
    {
        //EMPARENTAMOS LAS VARIABLES CON EL CONTROLADOR DE LA NAVE

        vertical = ShipManager.Vertical;
        horizontal = ShipManager.Horizontal;
        shooting = ShipManager.Fire;

        Rotate();
        Shoot();
    }

    //FIXED UPDATE NOS PERMITE DESPLAZAR UN OBJETO EN UN INTERVALO FIJO
    private void FixedUpdate()
    {
        //SELECCIONAMOS EL DESPLAZAMIENTO VERTICAL E IMPEDIMOS QUE NO PUEDA DESPLAZARSE NEGATIVAMENTE (DE REVERSA)
        var Motor = Mathf.Clamp(vertical, 0f, 1f);

        //LE ANADIMOS UNA FUERZA AL RIGIDBODY CON LAS RESTRICCIONES DE LA VARIABLE MOTOR, DE IGUAL MANERA
        //LA FUERZA UNICAMENTE FUNCIONARA EN EL EJE DE LAS Y
        shipBody.AddForce(transform.up * speed * Motor);

        //ASIGNAMOS UN LIMITE A TRAVES DE LA VARIABLE maxSpeed
        if(shipBody.velocity.magnitude > maxSpeed)
        {
            //SEGUIREMOS MOVIENDONOS PERO SIN REBASAR LA VELOCIDAD MAXIMA
            shipBody.velocity = shipBody.velocity.normalized * maxSpeed;

        }
    }

    //METODO PARA ROTAR LA NAVE
    private void Rotate()
    {
        //SI NOS DESPLAZAMOS DE IZQUIERDA A DERECHA NO PODREMOS ROTAR
        if (horizontal == 0)
        {
            return;
        }
        //PERO SIN NOS MOVEMOS DE ABAJO HACIA ARRIBA ROTAREMOS SEGUN SEA EL VALOR DE angularSpeed
        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);

    }

    //METODO DISPARO

    private void Shoot()
    {
        if (shooting && CanShoot)
        {
            StartCoroutine(FireRate());
            {

            }

        }
    }
    
    private IEnumerator FireRate()
    {
        CanShoot = false;

        //SE ASIGNA UN EJE DE MOVIMIENTO Y POSICION INICIAL DE LA BALA
        var pos = transform.up * bulletPosition + transform.position;

        //SE INSTANCIA EL PREFAB DE LA BALA CON LOS VALORES DE LA ANTERIOR LINEA
        var bullet = Instantiate(bulletPrefab, pos, transform.rotation);

        //SE DESTRUYE DESPUES DE 5 SEGUNDOS
        Destroy(bullet, 5);
                
            yield return new WaitForSeconds (ShootTime);

        CanShoot = true;

    }
}
