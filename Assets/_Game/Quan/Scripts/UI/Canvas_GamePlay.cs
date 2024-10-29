using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_GamePlay : Singleton<Canvas_GamePlay>
{
    //[SerializeField] WaveUI waveUI;
    private void Start()
    {
        
    }
    public void OnPause()
    {
        Time.timeScale = 0;
    }

    public void AddWaveController(WaveController waveController)
    {
      //  waveUI.AddWaveController(waveController);
    }
}
