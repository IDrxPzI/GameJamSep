using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    [SerializeField] private int currentWeapon;

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
            Vector3 direction = hitInfo.point - transform.position;
            transform.rotation = Quaternion.LookRotation(-direction);
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
                    enemy.TakeDamage(WeaponDamage(currentWeapon));
                }
            }
        }
    }

    private int WeaponDamage(int weapons)
    {
        for (int i = 0; i < currentWeapon; i++)
        {
            switch (weapons)
            {
                case 1:
                    damage = this.weapons[i].damage;
                    break;
                case 2:
                    damage = this.weapons[i].damage;
                    break;
                case 3:
                    damage = this.weapons[i].damage;
                    break;
                case 4:
                    damage = this.weapons[i].damage;
                    break;
                case 5:
                    damage = this.weapons[i].damage;
                    break;
            }
        }

        return damage;
    }
}


[System.Serializable]
struct Weapons
{
    public Mesh weaponMesh;
    public int ID;
    public int damage;
}