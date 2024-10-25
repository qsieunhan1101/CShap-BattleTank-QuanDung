using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] protected GameObject WaveListContainer;
    [SerializeField] protected GameObject effectSpawn;
    [SerializeField] protected GameObject ListEnemy;
    [SerializeField] protected float timeDestroyEffect = 0.5f;
    private int currentWaveIndex = 0;

    private void Start()
    {
        SpawnWave(currentWaveIndex);
    }

    [ContextMenu("Spawn")]
    private void SpawnWave(int waveIndex)
    {
        if (waveIndex >= waves.Count) return;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.enemyPrefabs.Length; i++)
        {
            for (int j = 0; j < wave.enemyCounts[i]; j++)
            {
                GameObject tank = Instantiate(wave.enemyPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
                tank.transform.SetParent(WaveListContainer.transform);
                GameObject effect = Instantiate(wave.enemyPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
                Destroy(effect, timeDestroyEffect);
            }
        }
    }
    [ContextMenu("Clear")]
    public void OnWaveComplete()
    {
        currentWaveIndex++;
        if (currentWaveIndex < waves.Count)
        {
            SpawnWave(currentWaveIndex);
        }
        else
        {
            Debug.Log("All waves completed!");
        }
    }
}