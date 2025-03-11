using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveConfig[] waveConfigs;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private float waveInterval = 5f;
    [SerializeField] private float initialDelay = 15f; // Добавляем поле для начальной задержки

    public event Action<int, int> OnWaveUpdated;

    private int currentWaveIndex = 0;
    private int enemiesRemaining = 0;

    private void Start()
    {
        StartCoroutine(StartNextWave());
    }

    private IEnumerator StartNextWave()
    {
        
        yield return new WaitForSeconds(initialDelay);

        while (currentWaveIndex < waveConfigs.Length)
        {
            WaveConfig currentWaveConfig = waveConfigs[currentWaveIndex];
            enemiesRemaining = currentWaveConfig.enemiesToSpawn;
            OnWaveUpdated?.Invoke(enemiesRemaining, currentWaveIndex + 1);

            enemySpawner.SpawnWave(currentWaveConfig, OnEnemyDestroyed);

            yield return new WaitUntil(() => enemiesRemaining <= 0);
            yield return new WaitForSeconds(waveInterval);

            currentWaveIndex++;
        }
    }

    private void OnEnemyDestroyed()
    {
        enemiesRemaining--;
        OnWaveUpdated?.Invoke(enemiesRemaining, currentWaveIndex + 1);
    }
}
