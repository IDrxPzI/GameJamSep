using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class Enemy_Slime : MonoBehaviour
{
    public GameObject audio_Death;
    public GameObject player;
    public GameObject projectile;
    public Transform point;
    public float speed = 5;
    public float maxDistance = 5;
    public bool isWait = false;
    public int slimeHP = 1;

    public bool death, GreiftAn;
    public float slimeAvoidSpeed = 10000f;

    [SerializeField] private Vector3 minScale = new Vector3(0.4f, 0.4f, 0.4f);

    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;

    public enum Enemystate { Chase, Attack };
    public Enemystate enemystate = Enemystate.Chase;


    private Vector3 objectScale;

    public Animator anim;

    private void Awake()
    {
        objectScale = transform.localScale;

        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if (!death && !GreiftAn)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
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
    public void Attack()
    {

        //Animation 
        if (slimeHP > 1)
        {
            GreiftAn = false;
            anim.SetTrigger("attack");
        }            
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = point.forward * speed;
        }

    }



    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Player")
        {
            DoDmg(10);
        }
        if (enemy.gameObject.tag != "Enemy") return;
        Vector3 avoidDirection = enemy.gameObject.transform.position - transform.position;
        avoidDirection.Normalize();
        rb.velocity = new Vector3(avoidDirection.x * slimeAvoidSpeed * -1, 0f, avoidDirection.z * slimeAvoidSpeed * -1);
        
    }
    
    public static float Distanz(Vector3 _v1, Vector3 _v2)
    {
        return (float)Math.Pow(((_v1.x - _v2.x) * (_v1.x - _v2.x)) + ((_v1.y - _v2.y) * (_v1.y - _v2.y)) + ((_v1.z - _v2.z) * (_v1.z - _v2.z)), 0.5);
    }

    public void TakeDamage1(int amount)
    {
        slimeHP -= amount;
        Destroy(Instantiate(audio_Death, new Vector3(0, 0, 0), Quaternion.identity), 5);

        if (slimeHP <= 0)
        {
            death = true;

            PlayDeathAnimation();
        }


        //compare scale to minScale to keep it from been to small
        var compareX = objectScale.x <= minScale.x;
        var compareY = objectScale.y <= minScale.y;
        var compareZ = objectScale.z <= minScale.z;

        if (compareX | compareY | compareZ)
        {
            objectScale = minScale;
            return;
        }

        objectScale *= 0.85f;

        transform.localScale = objectScale;
    }

    public void DestroyGameobject()
    {
        if (slimeHP <= 0)
        {
            //später einfügen
            EnemyDrops drops = new EnemyDrops();
            drops.DropItems();
            Destroy(gameObject);
        }
    }

    void PlayDeathAnimation()
    {
        anim.SetTrigger("death");
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = false;
    }
    }

    public void Shoot_Kugel()
    {
        TakeDamage1(1);
        GameObject bul = (GameObject)Instantiate(projectile, point.transform.position, Quaternion.identity);
        bul.gameObject.GetComponent<Rigidbody>().velocity = point.forward * speed;

    }

    public void Greift_Nicht_Mehr_An()
    {
        GreiftAn = false;
    }

    void DoDmg(int dmg)
    {
        player.GetComponent<PlayerMovement>().GetDmg(dmg);
    }
}

