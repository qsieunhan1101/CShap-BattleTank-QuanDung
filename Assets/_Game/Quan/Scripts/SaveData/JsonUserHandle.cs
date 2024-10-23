using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonUserHandle : MonoBehaviour
{
    public void SaveData(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData);

        PlayerPrefSave(Constant.KEY_PLAYERDATA, json);
    }

    public PlayerData LoadData()
    {
        if (PlayerPrefs.HasKey(Constant.KEY_PLAYERDATA))
        {
            string json = PlayerPrefs.GetString(Constant.KEY_PLAYERDATA);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            return playerData;
        }

        return new PlayerData(new int(), new int(), new List<TankName>(), new List<int>(), new List<int>());
    }

    private void PlayerPrefSave(string key, string json)
    {
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }
}

