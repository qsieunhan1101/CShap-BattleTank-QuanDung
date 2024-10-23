using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Canvas_Gold : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
    }

    private void UpdateGoldText()
    {
        goldText.text = DataManager.Instance.GetPlayerDataGold().ToString();
    }
}
