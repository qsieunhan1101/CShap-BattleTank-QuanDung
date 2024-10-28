using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveController : MonoBehaviour
{
    public UnityEvent OnWaveCompleted = new UnityEvent();

    [Header("Wave Spawn Points")]
    [SerializeField] private List<Wave> waves;
    [SerializeField] private List<Transform> spawnPoints;

    [Header("Wave List")]
    [SerializeField] private GameObject WaveListContainer;
    [SerializeField] private GameObject effectSpawn;
    [SerializeField] private List<GameObject> ListEnemy = new List<GameObject>();
    [SerializeField] private float timeDestroyEffect = 0.5f;
    public GameObject spawnPointContainer;

    [SerializeField] private int currentWaveIndex = 0;
    
    [SerializeField] private int totalEnemies = 0;
    [SerializeField] private int totalEnemiesKilled = 0;
    [SerializeField] private int currentWaveEnemiesKilled = 0;
    [SerializeField] private int currentWaveEnemyCount = 0;

    private void Start()
    {
        CalculateTotalEnemyCount();
        TryGetPoint();
        SpawnWave(currentWaveIndex);
        OnWaveCompleted.AddListener(OnWaveComplete);
    }

    private void CalculateTotalEnemyCount()
    {
        totalEnemies = 0;
        totalEnemiesKilled = 0;
        foreach (var wave in waves)
        {
            for (int i = 0; i < wave.enemyCounts.Length; i++)
            {
                totalEnemies += wave.enemyCounts[i];
            }
        }
    }

    private void SpawnWave(int waveIndex)
    {
        if (waveIndex >= waves.Count) return;

        Wave wave = waves[waveIndex];
        currentWaveEnemiesKilled = 0;
        currentWaveEnemyCount = 0;

        for (int i = 0; i < wave.enemyCounts.Length; i++)
        {
            currentWaveEnemyCount += wave.enemyCounts[i];
        }

        StartCoroutine(SpawnEnemies(wave));
    }

    private IEnumerator<WaitForSeconds> SpawnEnemies(Wave wave)
    {
        for (int i = 0; i < wave.enemyPrefabs.Length; i++)
        {
            for (int j = 0; j < wave.enemyCounts[i]; j++)
            {
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                GameObject effect = Instantiate(effectSpawn, randomSpawnPoint.position, randomSpawnPoint.rotation);
                GameObject enemy = Instantiate(wave.enemyPrefabs[i], randomSpawnPoint.position, randomSpawnPoint.rotation);
                enemy.transform.SetParent(WaveListContainer.transform);
                Destroy(effect, timeDestroyEffect);

                enemy.GetComponent<Enemy>().OnDestroyed.AddListener(UpdateEnemyCount);
                ListEnemy.Add(enemy);

                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    public void UpdateEnemyCount()
    {
        currentWaveEnemiesKilled++;
        totalEnemiesKilled++;
        if (currentWaveEnemiesKilled >= currentWaveEnemyCount)
        {
            OnWaveCompleted.Invoke();
        }
    }

    public void OnWaveComplete()
    {
        currentWaveIndex++;
        if (currentWaveIndex < waves.Count)
        {
            SpawnWave(currentWaveIndex);
        }
        else
        {
            ListEnemy.Clear();
            Debug.Log("All waves completed!");
        }
    }

    private void TryGetPoint()
    {
        if (spawnPointContainer != null)
        {
            foreach (Transform point in spawnPointContainer.transform)
            {
                if (point != null)
                {
                    spawnPoints.Add(point);
                }
            }
        }
    }

    public float GetPercentage()
    {
        return totalEnemies > 0 ? ( 1 -  (float)totalEnemiesKilled / totalEnemies ): 0f ;
    }
}
