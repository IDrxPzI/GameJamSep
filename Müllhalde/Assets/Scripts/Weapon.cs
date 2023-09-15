using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private void Update()
    {
        Debug.DrawLine(transform.position, new UnityEngine.Vector3(0, 0, 100), Color.green);
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
        }
    }
}