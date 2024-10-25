using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    [Header("Prefab Settings")]
    public GameObject[] prefabs; // Array of prefabs to instantiate
    public List<Transform> rows; // List of row transforms

    [Header("Spawn Limits")]
    public int[] spawnLimits; // Maximum number of each prefab to spawn

    public Transform EnemySpawnListContainer;
    [SerializeField]
    private Dictionary<GameObject, int> prefabCounts; // Count of spawned prefabs
    [SerializeField]
    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to track instantiated objects




    void OnEnable()
    {
    }

    [ContextMenu("Initialize Prefab Counts")]
    public void InitializePrefabCounts()
    {
        prefabCounts = new Dictionary<GameObject, int>();
        for (int i = 0; i < prefabs.Length; i++)
        {
            prefabCounts[prefabs[i]] = 0; // Initialize counts
        }
    }

    [ContextMenu("Spawn")]
    public void FillMatrix()
    {
        InitializePrefabCounts(); // Initialize counts when the object is enabled

        List<Transform> spawnPoints = new List<Transform>();

        foreach (Transform row in rows)
        {
            for (int col = 0; col < row.childCount; col++)
            {
                Transform child = row.GetChild(col);
                if (child.childCount == 0)
                {
                    spawnPoints.Add(child); 
                }
            }
        }

        Shuffle(spawnPoints);

        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject prefabToInstantiate = GetRandomPrefab();
            if (prefabToInstantiate != null)
            {
                if (!prefabToInstantiate.CompareTag(ConstProperty.SpawnPoint)) {
                    GameObject newObject = Instantiate(prefabToInstantiate, spawnPoint.position, Quaternion.identity, spawnPoint);
                    spawnedObjects.Add(newObject);
                } else
                {
                    GameObject enemySpawnPoint = Instantiate(prefabToInstantiate, spawnPoint.position, Quaternion.identity, EnemySpawnListContainer);
                    spawnedObjects.Add(enemySpawnPoint);
                } 

                
            }
        }
    }

    private GameObject GetRandomPrefab()
    {
        List<GameObject> availablePrefabs = new List<GameObject>();

        for (int i = 0; i < prefabs.Length; i++)
        {
            if (prefabCounts[prefabs[i]] < spawnLimits[i])
            {
                availablePrefabs.Add(prefabs[i]);
            }
        }

        if (availablePrefabs.Count > 0)
        {
            GameObject selectedPrefab = availablePrefabs[Random.Range(0, availablePrefabs.Count)];
            prefabCounts[selectedPrefab]++;
            return selectedPrefab;
        }

        return null; 
    }

    private void Shuffle(List<Transform> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Transform temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    [ContextMenu("Clear")]
    public void ClearMatrix()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                DestroyImmediate(obj); // Destroy the instantiated GameObject
            }
        }
        spawnedObjects.Clear(); // Clear the list after destroying the objects
    }
}