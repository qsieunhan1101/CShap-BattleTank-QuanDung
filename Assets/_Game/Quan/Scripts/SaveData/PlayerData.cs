using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int gold;
    public int levelMap;
    //tankoner Dictionary<id, state, tanklevel>

    public List<TankName> tankNames;
    public List<int> tankStates;
    public List<int> tankLevels;
    public PlayerData()
    {
        this.gold = new int();
        this.levelMap = new int();
        this.tankNames = new List<TankName>();
        this.tankStates = new List<int>();
        this.tankLevels = new List<int>();
    }
    public PlayerData(int gold, int levelMap, List<TankName> tankNames, List<int> tankStates, List<int> tankLevels)
    {
        this.gold = gold;
        this.levelMap = levelMap;
        this.tankNames = tankNames;
        this.tankStates = tankStates;
        this.tankLevels = tankLevels;
    }

    
}