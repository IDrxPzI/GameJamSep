using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{



    // public Enemy()
    // {
    //     //LevelManager levelManager = new LevelManager();
    //     //spawnPoints = levelManager.spawnPoints;
    //
    //     for (int i = 0; i < 10; i++)
    //     {
    //         int randomPosition = Random.Range(0, spawnPoints.Length);
    //
    //         //Enemy spawnrates
    //         int range = Random.Range(0, 16);
    //         switch (range)
    //         {
    //             case <= 10:
    //
    //                 //var enemy = Instantiate(transform, spawnPoints[randomPosition]);
    //                 enemyMaterial = enemys[0].enemyMaterial;
    //                 HP = enemys[0].enemyHP;
    //                 Damage = enemys[0].enemyDamage;
    //
    //                 //spawn green enemy   
    //                 break;
    //             case > 10 and < 15:
    //
    //                 enemyMaterial = enemys[1].enemyMaterial;
    //                 HP = enemys[1].enemyHP;
    //                 Damage = enemys[1].enemyDamage;
    //
    //                 //spawn blue enemy
    //                 break;
    //             case 15:
    //                 enemyMaterial = enemys[2].enemyMaterial;
    //                 HP = enemys[2].enemyHP;
    //                 Damage = enemys[2].enemyDamage;
    //
    //                 //spawn red enemy
    //                 break;
    //
    //
    //             //case int n when (n > 10 | n < 15):
    //         }
    //
    //         var enemy = Instantiate(transform, spawnPoints[randomPosition]);
    //     }
    // }

    /*private void Update()
    {
        DestroyGameobject();
    }

    void DestroyGameobject()
    {
        if (HP <= 0)
        {
            EnemyDrops drops = new EnemyDrops();
            drops.DropItems();

            Destroy(gameObject);
        }
    }
    */
   
}