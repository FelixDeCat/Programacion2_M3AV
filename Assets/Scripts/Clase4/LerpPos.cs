using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPos : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;

    float timer = 0;
    [SerializeField] float timeToLerp = 1;

    // Update is called once per frame
    void Update()
    {
        if (timer < timeToLerp)
        {
            timer = timer + 1 * Time.deltaTime;
            target.position = Vector3.Lerp(pos1.position, pos2.position, timer / timeToLerp);
        }
        else
        {
            timer = 0;
        }  
    }
}
