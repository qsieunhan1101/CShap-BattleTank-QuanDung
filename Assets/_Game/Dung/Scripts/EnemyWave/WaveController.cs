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

    public GameObject spawnPointContainer;
    private int currentWaveIndex = 0;

    [field : SerializeField]
    public int TotalEnemyCount { get; private set; }
    private void Start()
    {
        TryGetPoint();
        SpawnWave(currentWaveIndex);
    }

    private void TryGetPoint()
    {
        if (spawnPoints.Count > 0)
        {
            bool hasNullTransform = false;

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                if (spawnPoints[i] == null)
                {
                    hasNullTransform = true;
                    break;
                }
            }

            if (hasNullTransform)
            {
                spawnPoints.Clear();
            }
        }
        if (spawnPointContainer != null)
        {
            foreach (Transform point in spawnPointContainer.transform)
            {
                spawnPoints.Add(point);
            }
        }
    }


    [ContextMenu("Spawn")]
    private void SpawnWave(int waveIndex)
    {
        if (waveIndex >= waves.Count) return;

        Wave wave = waves[waveIndex];
        TotalEnemyCount = 0;
        for (int i = 0; i < wave.enemyCounts.Length; i++)
        {
            TotalEnemyCount += wave.enemyCounts[i];
        }
        for (int i = 0; i < wave.enemyPrefabs.Length; i++)
        {
            for (int j = 0; j < wave.enemyCounts[i]; j++)
            {
                GameObject tank = Instantiate(wave.enemyPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
                tank.transform.SetParent(WaveListContainer.transform);

                tank.GetComponent<Enemy>().OnDestroyed.AddListener(UpdateEnemyCount);

                GameObject effect = Instantiate(wave.enemyPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
                Destroy(effect, timeDestroyEffect);
            }
        }
    }

    private void UpdateEnemyCount()
    {
        TotalEnemyCount--;
        if (TotalEnemyCount <= 0)
        {
            OnWaveComplete(); 
        }
    }

    [ContextMenu("CompleteWave")]
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