using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    [SerializeField] public static int currentWeapon = 1;

    [SerializeField] public GameObject weaponPrefab;

    [SerializeField] public GameObject bulletPrefab;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private float bulletSpeed = 1;
    [SerializeField] private int damage = 10;
    [SerializeField] private float range = 100;

    [SerializeField] private Weapons[] weapons;

    private void Start()
    {
        //GameEvents.Instance.onTargetHit += UpgradeWeapon;
    }

    private void Update()
    {
        RotateGun();
    }

    void UpgradeWeapon()
    {
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
                Enemy_Slime enemy = hit.transform.GetComponent<Enemy_Slime>();

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

    private void OnDestroy()
    {
        //GameEvents.Instance.onTargetHit -= UpgradeWeapon;
    }
}


[System.Serializable]
struct Weapons
{
    public GameObject weaponPrefab;
    public int ID;
    public int damage;

    public Weapons(GameObject _prefab, int _ID, int _damage)
    {
        weaponPrefab = null;
        ID = 0;
        damage = 0;
    }
}