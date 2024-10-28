using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpawnWave : MonoBehaviour
{
    [SerializeField] private WaveController waveController;

    private void OnEnable()
    {
        Canvas_GamePlay.Instance.AddWaveController(waveController);
    }
}
