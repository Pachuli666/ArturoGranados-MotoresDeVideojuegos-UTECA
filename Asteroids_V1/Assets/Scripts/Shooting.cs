using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float speed;

    private void Update()
    {
            //EL MOVIMIENTO SE ORIENTA HACIA ADELANTA Y SE MULTIPLICA POR LA VELOCIDAD Y EL TIEMPO
            transform.position += transform.up * speed * Time.deltaTime;
    }
}
