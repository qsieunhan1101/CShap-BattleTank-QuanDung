using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private Slider enemySlider;
    [SerializeField] private WaveController waveController;

    private void OnEnable()
    {
        waveController.OnEnemyDied.AddListener(UpdateSlider);
        waveController.OnWaveCompleted.AddListener(UpdateSlider);
    }

    private void OnDisable()
    {
        waveController.OnEnemyDied.RemoveListener(UpdateSlider);
        waveController.OnWaveCompleted.RemoveListener(UpdateSlider);
    }

    private void Start()
    {
        enemySlider.maxValue = waveController.TotalEnemyHere; 
        enemySlider.value = enemySlider.maxValue; 
    }

    private void UpdateSlider()
    {
        enemySlider.value = waveController.TotalEnemyHere;
    }
}