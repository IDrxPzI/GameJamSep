using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int HP = 100;
    [SerializeField] public int Damage = 100;
    [SerializeField] private Vector3 minScale = new Vector3(0.4f, 0.4f, 0.4f);

    private Vector3 objectScale;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject enemyPrefab;


    [SerializeField] private EnemyType[] enemys;

    private Material enemyMaterial;

    private void Awake()
    {
        //spawnPoints = levelManager.spawnPoints;
        // GameEvents.Instance.onTargetHit += DestroyGameobject;

        enemyMaterial = GetComponent<MeshRenderer>().material;

        objectScale = transform.localScale;
    }

    public Enemy()
    {
        //LevelManager levelManager = new LevelManager();
        //spawnPoints = levelManager.spawnPoints;

        for (int i = 0; i < 10; i++)
        {
            int randomPosition = Random.Range(0, spawnPoints.Length);

            //Enemy spawnrates
            int range = Random.Range(0, 16);
            switch (range)
            {
                case <= 10:

                    //var enemy = Instantiate(transform, spawnPoints[randomPosition]);
                    enemyMaterial = enemys[0].enemyMaterial;
                    HP = enemys[0].enemyHP;
                    Damage = enemys[0].enemyDamage;

                    //spawn green enemy   
                    break;
                case > 10 and < 15:

                    enemyMaterial = enemys[1].enemyMaterial;
                    HP = enemys[1].enemyHP;
                    Damage = enemys[1].enemyDamage;

                    //spawn blue enemy
                    break;
                case 15:
                    enemyMaterial = enemys[2].enemyMaterial;
                    HP = enemys[2].enemyHP;
                    Damage = enemys[2].enemyDamage;

                    //spawn red enemy
                    break;


                //case int n when (n > 10 | n < 15):
            }

            var enemy = Instantiate(transform, spawnPoints[randomPosition]);
        }
    }

    private void Update()
    {
        DestroyGameobject();
    }

    void DestroyGameobject()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        if (HP <= 1)
        {
            EnemyDrops drops = new EnemyDrops();
            drops.DropItems();

            Destroy(gameObject);
        }

        HP -= amount;

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
}