using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private Slider enemySlider;
    [SerializeField] private List<WaveController> waveControllers;
    private WaveController currentWayController;
    [SerializeField]
    private int currentLevelIndex = 0;

    private void Start()
    {
        SetDefaultLevelIndex();
    }


    private void Update()
    {
        if (waveControllers != null && currentLevelIndex < waveControllers.Count)
        {
            UpdateSlider();
        }
    }

    private void SetDefaultLevelIndex()
    {
        for (int i = 0; i < waveControllers.Count; i++)
        {
            if (waveControllers[i].gameObject.activeInHierarchy)
            {
                currentLevelIndex = i;
                UpdateSlider();
                break; 
            }
        }
    }

    public void RegisterWaveController(WaveController waveController)
    {
        waveControllers.Add(waveController);
        currentLevelIndex = waveControllers.Count - 1;
        UpdateSlider(); 
    }
    public void UpdateSlider()
    {
        if (waveControllers[currentLevelIndex] != null && enemySlider != null)
        {
            enemySlider.value = waveControllers[currentLevelIndex].GetPercentage();
        }
    }

    public void SetCurrentLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < waveControllers.Count)
        {
            currentLevelIndex = levelIndex;
            UpdateSlider();
        }
    }

    public void AddWaveController(WaveController waveController)
    {
        waveControllers.Add(waveController);
    }
}
