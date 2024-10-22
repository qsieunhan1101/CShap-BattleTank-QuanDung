using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Drawers;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New LocalData", menuName ="LocalData")]
public class LocalData : ScriptableObject
{
    [SerializeField] private List<TankData> listTankData = new List<TankData>();



    [PreviewField] [SerializeField] private List<Sprite> listIconTank = new List<Sprite>();
    [SerializeField] private List<string> listNameTank = new List<string>();
    [SerializeField] private List<int> listPriceTank = new List<int>();
    [SerializeField] private List<int> listDameTank = new List<int>();
    [SerializeField] private List<int> listHpTank = new List<int>();
    [SerializeField] private List<int> listSpeedTank = new List<int>();


    public List<TankData> ListTankData => listTankData;


    [Button("LoadDataOnEditor")]
    public void LoadDataOnEditor()
    {
        listTankData = new List<TankData>();
        for (int i = 0; i < listIconTank.Count; i++)
        {
            listTankData.Add(new TankData());
            listTankData[i].iconTank = listIconTank[i];
            listTankData[i].nameTank = listNameTank[i];
            listTankData[i].priceTank = listPriceTank[i];
            listTankData[i].dameTank = listDameTank[i];
            listTankData[i].hpTank = listHpTank[i];
            listTankData[i].speedTank = listSpeedTank[i];
        }
    }
}

[Serializable]
public class TankData
{

    public string nameTank;
    [PreviewField] public Sprite iconTank;
    public GameObject iconTank3D;
    public int priceTank;
    public int dameTank;
    public int hpTank;
    public int speedTank;
}

public enum TankName
{
    Starter = 0,
    Panther = 1,
    Eagle = 2,
    Phoenix = 3,
    Justice = 4,
    Savior = 5,
    Chaostic = 6,
    Batman = 7,
    Warrior = 8,
    Destroyer = 9,
    Wolf = 10,
}