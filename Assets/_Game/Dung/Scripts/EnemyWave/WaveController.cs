using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveController : MonoBehaviour
{

    public UnityEvent OnEnemyDied = new UnityEvent();
    public UnityEvent OnWaveCompleted = new UnityEvent();

    [Header("Wave SpawnSpoint")]
    [SerializeField] private List<Wave> waves;
    [SerializeField] private List<Transform> spawnPoints;
    [Header("Wave List")]

    [SerializeField] protected GameObject WaveListContainer;
    [SerializeField] protected GameObject effectSpawn;
    [SerializeField] protected List<GameObject> ListEnemy = new List<GameObject>();

    [SerializeField] protected float timeDestroyEffect = 0.5f;

    public GameObject spawnPointContainer;



    private int currentWaveIndex = 0;
    [SerializeField]
    private int enemiesKilled = 0;
    public int EnemiesKilled => enemiesKilled;


    [field: SerializeField]
    private int TotalEnemyCount;

    public int TotalEnemyHere => TotalEnemyCount;

    private void Start()
    {
        TotalEnemyCount = 0;
        TryGetPoint();
        SpawnWave(currentWaveIndex);
        OnWaveCompleted.AddListener(OnWaveComplete);
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

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void UpdateEnemyCount()
    {

        enemiesKilled++;
        if (enemiesKilled >= TotalEnemyCount)
        {
            OnWaveCompleted.Invoke();
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
            ListEnemy.Clear();
            Debug.Log("All waves completed!");
        }
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
}