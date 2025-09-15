using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    Vector3 offset;

    [SerializeField] float smoothAmmount = 0.1f;

    private void Start()
    {
        offset = target.position + transform.position; 
    }

    Vector3 desired = Vector3.zero;

    Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        desired = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothAmmount);
    }
}
