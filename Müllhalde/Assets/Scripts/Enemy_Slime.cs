using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Slime : MonoBehaviour
{
    public GameObject player;
    public float maxDistance = 2;

    public float slimeAvoidSpeed = 1f;

    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;

    public enum Enemystate { Chase, Attack };
    public Enemystate enemystate = Enemystate.Chase;

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
        if (enemystate == Enemystate.Chase)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(player.transform.position);
        }
        if (Distanz(transform.position, player.transform.position) <= maxDistance)
        {
            enemystate = Enemystate.Attack;
            navMeshAgent.isStopped = true;
        }
        if (Distanz(transform.position, player.transform.position) > maxDistance)
        {

        }
    }



    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag != "Enemy") return;
        Vector3 avoidDirection = enemy.gameObject.transform.position - transform.position;
        avoidDirection.Normalize();
        rb.velocity = new Vector3(avoidDirection.x * slimeAvoidSpeed * -1, 0f, avoidDirection.z * slimeAvoidSpeed * -1);
        Debug.Log(avoidDirection);
    }
    public static float Distanz(Vector3 _v1, Vector3 _v2)
    {
        return (float)Math.Pow(((_v1.x - _v2.x) * (_v1.x - _v2.x)) + ((_v1.y - _v2.y) * (_v1.y - _v2.y)) + ((_v1.z - _v2.z) * (_v1.z - _v2.z)), 0.5);
    }
}

