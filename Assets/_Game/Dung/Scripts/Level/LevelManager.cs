using System;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameObject[] levelMapPrefabs;
    [SerializeField] private Transform levelParent;

    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private int currentLevel;


    public static Action<int> saveLevelEvent;

    #region Dung 
    [SerializeField] private WaveUI waveUI;

    #endregion
    void Start()
    {
    }

    void Update()
    {

    }


    public void LoadLevel(int levelIndex)
    {
        currentLevel = levelIndex;
        DestroyLevel();

        GameObject levelMap = Instantiate(levelMapPrefabs[levelIndex], levelParent);

        WaveController waveController = levelMap.GetComponent<WaveController>(); 

        GameObject player = Instantiate(playerPrefab, levelParent);

        if (waveUI != null && waveController != null)
        {
            waveUI.RegisterWaveController(waveController); 
        }

    }

    public void NextLevel()
    {
        currentLevel++;
        currentLevel = Mathf.Clamp(currentLevel, 0, levelMapPrefabs.Length - 1);
        LoadLevel(currentLevel);
    }
    public void ReLoadLevel()
    {
        LoadLevel(currentLevel);
    }


    public void SaveLevel()
    {
        saveLevelEvent?.Invoke(currentLevel);
    }

    public void LoadHighestLevel()
    {
        currentLevel = DataManager.Instance.PlayerData.levelMap;
        LoadLevel(currentLevel);
    }


    public void DestroyLevel()
    {
        foreach (Transform child in levelParent)
        {
            Destroy(child.gameObject);
        }
    }

}
