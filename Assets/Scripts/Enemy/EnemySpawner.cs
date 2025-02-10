using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject enemyPrefab;

    public void SpawnWave(WaveConfig waveConfig, Action onEnemyDestroyed)
    {
        StartCoroutine(SpawnEnemies(waveConfig, onEnemyDestroyed));
    }

    private IEnumerator SpawnEnemies(WaveConfig waveConfig, Action onEnemyDestroyed)
    {
        for (int i = 0; i < waveConfig.enemiesToSpawn; i++)
        {
            Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            var enemyHealth = enemy.GetComponent<ZombieHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.OnDeath += onEnemyDestroyed;
            }

            yield return null; // Можно добавить задержку между спавнами, если нужно
        }
    }
}
