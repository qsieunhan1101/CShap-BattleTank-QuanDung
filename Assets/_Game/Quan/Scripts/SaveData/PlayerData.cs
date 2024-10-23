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
    public List<int> tankOwner;
    public List<int> tankEquipState;
    public List<int> tankLevel;

    public PlayerData(int gold)
    {
        this.gold = gold;
    }
}