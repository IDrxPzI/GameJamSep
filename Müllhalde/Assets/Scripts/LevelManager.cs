using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    [SerializeField] private GameObject showInfoUI;

    [SerializeField] private TextMeshProUGUI ReoRecyclePoints;
    [SerializeField] private TextMeshProUGUI trashPoints;
    [SerializeField] private TextMeshProUGUI waveText;

    [SerializeField] private InputActionAsset player;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    private int enemySpawnAmount;

    private static int currentWave = 1;

    private bool waveActive;
    private bool countUp;

    private EnemyDrops drops;

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
        StartLevel();

        drops = new EnemyDrops();
        //test der spawn funktionalität
    }

    private void Update()
    {
        var openShopMenu = player.FindAction("OpenShopMenu");
        var startNewWave = player.FindAction("StartNextWave");

        if (waveActive)
        {
            startNewWave.Disable();
            openShopMenu.Disable();
        }
        else
        {
            openShopMenu.Enable();
        }

        LevelEnd();


        ReoRecyclePoints.SetText($"{drops.ReoPoints}");
        trashPoints.SetText($"{drops.TrashPoints}");
    }

    public void StartLevel()
    {
        showInfoUI.SetActive(false);

        UpdateWaveText();

        waveActive = true;
        countUp = false;

        enemySpawnAmount = Random.Range(2 + currentWave, 4 + currentWave);

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            int randomPosition = Random.Range(0, spawnPoints.Length);
            var enemy = Instantiate(enemyPrefab, spawnPoints[randomPosition]);
            enemy.transform.parent = transform;
            enemy.GetComponent<Enemy_Slime>().slimeHP = 3;
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
        if (transform.childCount <= 0 && !countUp)
        {
            currentWave++;
            countUp = true;
            WaveFinished();
        }
    }

    void WaveFinished()
    {
        //Show Levelstart Button
        //Show direction of the shop? / open shop on button
        var startNewWave = player.FindAction("StartNextWave");
        startNewWave.Enable();

        waveText.SetText($"Wave Finished");
        showInfoUI.SetActive(true);

        waveActive = false;
    }

    void UpdateWaveText()
    {
        waveText.SetText($"Wave {currentWave}");
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