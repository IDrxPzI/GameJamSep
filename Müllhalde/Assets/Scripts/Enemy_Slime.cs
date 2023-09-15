using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Slime : MonoBehaviour
{
    public GameObject player;

    public float slimeAvoidSpeed = 1;

    private NavMeshAgent navMeshAgent;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag != "Enemy") return;
        UnityEngine.Vector3 avoidDirection = Vector3.Minus(
            transform.position, 
            enemy.gameObject.transform.position
        );

        transform.position = new UnityEngine.Vector3(
            avoidDirection.x*slimeAvoidSpeed*Time.deltaTime, 
            0, 
            avoidDirection.z*slimeAvoidSpeed*Time.deltaTime
        );
    }
}

