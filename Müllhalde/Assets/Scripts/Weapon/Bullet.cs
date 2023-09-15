using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeTime = 5;

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameEvents.Instance.TargetHitEvent();

            Destroy(gameObject);
        }
    }
}