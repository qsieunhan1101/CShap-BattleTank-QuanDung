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
    [SerializeField] private PlayerData playerData = new PlayerData();
    

    public LocalData LocalData => localData;
    public PlayerData PlayerData => playerData;

    private void Start()
    {
        if (IsFirstRunGame() == true)
        {
            Debug.Log("Lan dau chay game");
            PlayerPrefs.SetInt(Constant.KEY_FIRSTRUN, 0);
            PlayerPrefs.Save();
            PlayerFirstRunGameData();
        }
        else
        {
            LoadPlayerData();
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
        playerData = new PlayerData(playerDataFirstRun.playerData.gold, playerDataFirstRun.playerData.levelMap, playerDataFirstRun.playerData.tankNames, playerDataFirstRun.playerData.tankStates, playerDataFirstRun.playerData.tankLevels);



        SaveAndLoadPlayerData();

        //Luu lai trang thai da chay game
    
    }

    private void SaveAndLoadPlayerData()
    {
        SavePlayerData();
        LoadPlayerData();
    }
    private void SavePlayerData()
    {
        jsonUserHandle.SaveData(playerData);
    }

    private void LoadPlayerData()
    {
        playerData = jsonUserHandle.LoadData();
    }

    public int GetPlayerDataGold()
    {
        return jsonUserHandle.LoadData().gold;
    }
}

