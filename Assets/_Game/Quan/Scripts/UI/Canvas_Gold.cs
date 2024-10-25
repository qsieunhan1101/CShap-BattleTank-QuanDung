using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Canvas_Gold : Singleton<Canvas_Gold>
{
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
    }

    public void UpdateGoldText()
    {
        goldText.text = DataManager.Instance.GetPlayerDataGold().ToString();
    }
}
