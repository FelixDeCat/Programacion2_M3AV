using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;

    [SerializeField] Rigidbody rb;

    [SerializeField] float speed = 200f;

    [SerializeField] float radius = 10;

    void Start()
    {
        target = GameMamager.instance.player.transform;
    }

    Vector3 dir = Vector3.zero;

    void Update()
    {
        // direccion para la forma 1 y 3
        dir = target.position - this.transform.position;

        // forma 1. Puedo comparar [Radius] porque internamente magnitude tiene Raiz Cuadrada
        // if (dir.magnitude < radius) 

        // forma 2. Puedo comparar [Radius] porque internamente Distance tiene magnitude adentro y este a su vez tiene Raiz Cuadrada
        // vease que acá no necesitamos la direccion porque ya la hace tambien internamente
        // if (Vector3.Distance(target.position, this.transform.position) < radius) 
        
        //forma 3 : multiplico radius * radius porque sqrMagnitude NO TIENE la Raiz cuadrada, solo la potencia
        if (dir.sqrMagnitude < radius * radius) 
        {
            dir.Normalize();
        }
        else
        {
            dir = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed * Time.fixedDeltaTime;
    }
}
