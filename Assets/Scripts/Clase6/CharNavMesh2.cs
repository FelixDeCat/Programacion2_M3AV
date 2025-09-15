using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharNavMesh2 : MonoBehaviour
{
    [SerializeField] Transform dest;
    [SerializeField] NavMeshAgent agent;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            agent.SetDestination(dest.position);
        }
    }
}
