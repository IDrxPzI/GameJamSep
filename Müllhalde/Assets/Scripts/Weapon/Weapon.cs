using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private float bulletSpeed = 1;
    [SerializeField] private int damage = 10;
    [SerializeField] private float range = 100;

    [SerializeField] private Weapons[] weapons;

    private void Update()
    {
        RotateGun();
    }

    void RotateGun()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hitInfo))
        {
            UnityEngine.Vector3 direction = hitInfo.point - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    private int WeaponDamage()
    {
        return 0;
    }
}


[System.Serializable]
struct Weapons
{
    public Mesh weaponMesh;
    public int ID;
    public int damage;
}