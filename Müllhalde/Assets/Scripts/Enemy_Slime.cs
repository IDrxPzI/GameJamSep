using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_Slime : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public Transform point;
    public float speed = 5;
    public float maxDistance = 5;
    public bool isWait = false;
    public int slimeHP = 1;

    public float slimeAvoidSpeed = 1f;

    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;

    public enum Enemystate { Chase, Attack };
    public Enemystate enemystate = Enemystate.Chase;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        Debug.Log(player.transform.position);
        
        navMeshAgent.SetDestination(player.transform.position);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        /*if (enemystate == Enemystate.Chase)
        {
            navMeshAgent.isStopped = false;
            
        }*/
        if (Distanz(transform.position, player.transform.position) <= maxDistance)
        {
            enemystate = Enemystate.Attack;
           // navMeshAgent.isStopped = true;
        }
        if (enemystate == Enemystate.Attack && isWait == false)
        {
            isWait = true;
            StartCoroutine(WaitBeforeGroundCheck());
        }


    }

    private IEnumerator WaitBeforeGroundCheck()
    {
        //GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        transform.LookAt(player.transform);
        Attack();

        yield return new WaitForSeconds(2f);
        enemystate = Enemystate.Chase;
        isWait = false;

    }
    void Attack()
    {

        //Animation 
        if (slimeHP > 1)
        {
            slimeHP--;
            GameObject bul = (GameObject)Instantiate(projectile, point.transform.position, Quaternion.identity);
            bul.gameObject.GetComponent<Rigidbody>().velocity = point.forward * speed;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = point.forward * speed;
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

