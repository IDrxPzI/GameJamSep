using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int HP = 100;
    [SerializeField] private Vector3 minScale = new Vector3(0.4f, 0.4f, 0.4f);

    private Vector3 objectScale;

    private void Awake()
    {
       // GameEvents.Instance.onTargetHit += DestroyGameobject;

        objectScale = transform.localScale;
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

    private void OnDestroy()
    {
        //GameEvents.Instance.onTargetHit -= DestroyGameobject;
    }
}