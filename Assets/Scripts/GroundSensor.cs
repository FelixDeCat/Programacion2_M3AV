using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] bool isGrounded = false;
    public Vector3 offset = Vector3.zero;
    public float radius = 1f;

    public LayerMask grounds;

    public bool IsGrounded
    {
        get 
        {
            return isGrounded;
        }
    }

    void Update()
    {
        var cols = Physics.OverlapSphere(transform.position + offset, radius, grounds);

        if (cols.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //// con volumen
        //Gizmos.DrawSphere(transform.position + offset, radius);

        Gizmos.color = Color.blue;
        // sin volumen
        Gizmos.DrawWireSphere(transform.position + offset, radius);
    }
}
