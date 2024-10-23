using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Experimental.GlobalIllumination;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private LocalData localData;
    [SerializeField] private PlayerDataFirstRun playerDataFirstRun;
    [SerializeField] private JsonUserHandle jsonUserHandle;    
    [SerializeField] private PlayerData playerData = new PlayerData(new int());
    

    public LocalData LocalData => localData;
    public PlayerData PlayerData => playerData;

    private void Start()
    {
        if (IsFirstRunGame() == true)
        {
            Debug.Log("Lan dau chay game");
            PlayerFirstRunGameData();
        }
        else
        {
            Debug.Log("khong phai lan dau chay game");

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerData.gold = 22;
            jsonUserHandle.SaveData(playerData);

            playerData = jsonUserHandle.LoadData();
        }
    }
    private bool IsFirstRunGame()
    {
        return !PlayerPrefs.HasKey(Constant.KEY_FIRSTRUN);
    }

    private void PlayerFirstRunGameData()
    {
        playerData = new PlayerData(playerDataFirstRun.playerData.gold);

        jsonUserHandle.SaveData(playerData);
        playerData = jsonUserHandle.LoadData();

        //Luu lai trang thai da chay game
        PlayerPrefs.SetInt(Constant.KEY_FIRSTRUN, 0);
        PlayerPrefs.Save();
    }
}

