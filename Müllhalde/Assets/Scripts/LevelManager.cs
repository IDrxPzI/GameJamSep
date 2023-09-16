using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    [SerializeField] private InputActionAsset player;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemySpawnAmount;

    private static int currentWave = 1;

    private bool waveActive;

    private void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //test der spawn funktionalität
        StartLevel();
    }

    private void Update()
    {
        var openShopMenu = player.FindAction("OpenShopMenu");

        if (waveActive)
        {
            openShopMenu.Disable();
        }
        else
        {
            openShopMenu.Enable();
        }
    }

    void StartLevel()
    {
        waveActive = true;

        enemySpawnAmount = Random.Range(2 + currentWave, 4 + currentWave);

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            int randomPosition = Random.Range(0, spawnPoints.Length);
            var enemy = Instantiate(enemyPrefab, spawnPoints[randomPosition]);
            enemy.transform.parent = transform;
        }
    }

    public void StartNextWave(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartLevel();
        }
    }

    void LevelEnd()
    {
        //if (transform.childCount >= 0)
        //{
        //    currentWave++;
        //    WaveFinished();
        //}
    }

    void WaveFinished()
    {
        //Show Levelstart Button
        //Show direction of the shop? / open shop on button

        //GameEvents.Instance.onDestroyObject -= LevelEnd;

        currentWave++;
        waveActive = false;
    }
}

[System.Serializable]
struct EnemyType
{
    public Material enemyMaterial;
    public int enemyHP;
    public int enemyDamage;

    public EnemyType(Material _enemyMaterial, int _HP, int _damage)
    {
        this.enemyMaterial = _enemyMaterial;
        this.enemyHP = _HP;
        this.enemyDamage = _damage;
    }
}