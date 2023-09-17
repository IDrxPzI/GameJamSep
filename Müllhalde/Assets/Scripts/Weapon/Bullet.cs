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
        
       // GameEvents.Instance.onTargetHit += TargetHitEvent;
    }
    


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Slimgetroffen");
            other.collider.GetComponent<Enemy_Slime>().TakeDamage1(1);
           // GameEvents.Instance.TargetHitEvent();

            Destroy(gameObject);
        }
    }
}