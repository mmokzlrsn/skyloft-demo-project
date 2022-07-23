using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerParentPathFind : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private Transform finish;


    //public Transform motorcycle;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = finish.position;
    }
}
