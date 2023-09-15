using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int HP = 100;
    [SerializeField] private UnityEngine.Vector3 minScale = new UnityEngine.Vector3(0.4f, 0.4f, 0.4f);

    private UnityEngine.Vector3 objectScale;

    private void Start()
    {
        // GameEvents.Instance.onTargetHit += BulletHit;

        objectScale = transform.localScale;
    }

    public void TakeDamage(int amount)
    {
        if (HP <= 0)
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