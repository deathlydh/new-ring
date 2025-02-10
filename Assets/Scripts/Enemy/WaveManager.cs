using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveConfig[] waveConfigs;  // Массив WaveConfig для всех волн
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private float waveInterval = 5f; // Задержка между волнами

    public event Action<int, int> OnWaveUpdated; // Кол-во врагов, номер волны

    private int currentWaveIndex = 0; // Индекс текущей волны
    private int enemiesRemaining = 0;

    private void Start()
    {
        StartCoroutine(StartNextWave());
    }

    private IEnumerator StartNextWave()
    {
        // Будем ждать завершения текущей волны, если волна не завершена
        while (currentWaveIndex < waveConfigs.Length)
        {
            // Получаем количество врагов для текущей волны из массива
            WaveConfig currentWaveConfig = waveConfigs[currentWaveIndex];
            enemiesRemaining = currentWaveConfig.enemiesToSpawn;
            OnWaveUpdated?.Invoke(enemiesRemaining, currentWaveIndex + 1);

            // Спавним врагов текущей волны
            enemySpawner.SpawnWave(currentWaveConfig, OnEnemyDestroyed);

            // Ждём, пока все враги будут уничтожены
            yield return new WaitUntil(() => enemiesRemaining <= 0);

            // После завершения волны, делаем паузу перед началом новой
            yield return new WaitForSeconds(waveInterval);

            // Переходим к следующей волне
            currentWaveIndex++;
        }
    }

    private void OnEnemyDestroyed()
    {
        enemiesRemaining--;
        OnWaveUpdated?.Invoke(enemiesRemaining, currentWaveIndex);

        // Проверка на завершение волны уже происходит через WaitUntil в StartNextWave
    }
}
