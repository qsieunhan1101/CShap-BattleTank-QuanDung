using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private LocalData localData;


    public LocalData LocalData => localData;
}
