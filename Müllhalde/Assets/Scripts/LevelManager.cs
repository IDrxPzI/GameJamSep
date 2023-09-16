using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int spawnAmount;

    private void Start()
    {
        StartLevel();
    }

    void StartLevel()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            int randomPosition = Random.Range(0, spawnPoints.Length);
            var enemy = Instantiate(enemyPrefab, spawnPoints[randomPosition]);
        }
    }
}