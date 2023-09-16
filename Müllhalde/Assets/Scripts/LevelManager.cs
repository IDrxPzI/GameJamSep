using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemySpawnAmount;

    [SerializeField] private EnemyType[] enemys;

    private Material enemyMaterial;

    private void Start()
    {
        enemyMaterial = enemyPrefab.GetComponent<MeshRenderer>().sharedMaterial;

        //test der spawn funktionalität
        StartLevel();
    }

    void StartLevel()
    {
        // Dictionary<GameObject, EnemyType> enemyTypesDic = new Dictionary<GameObject, EnemyType>();

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            int randomPosition = Random.Range(0, spawnPoints.Length);
            var enemy = Instantiate(enemyPrefab, spawnPoints[randomPosition]);

            //enemyTypesDic.Add((GameObject)Instantiate(enemyPrefab, spawnPoints[randomPosition]), new EnemyType());
        }
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