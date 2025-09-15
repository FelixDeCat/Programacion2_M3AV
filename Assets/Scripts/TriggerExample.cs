using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();


        if (player != null)
        {
            Debug.Log("<color=red>COlisionee con el player</color>");
        }
    }
    private void OnDrawGizmos()
    {
        
    }
}
