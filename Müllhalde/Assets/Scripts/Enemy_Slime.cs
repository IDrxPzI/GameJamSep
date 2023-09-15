using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Slime : MonoBehaviour
{
    public GameObject player;

    public float slimeAvoidSpeed = 1f;

    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag != "Enemy") return;
        Vector3 avoidDirection = enemy.gameObject.transform.position - transform.position;
        avoidDirection.Normalize();
        rb.velocity = new Vector3(avoidDirection.x * slimeAvoidSpeed*-1, 0f, avoidDirection.z* slimeAvoidSpeed);
        Debug.Log(avoidDirection);
    }
}

