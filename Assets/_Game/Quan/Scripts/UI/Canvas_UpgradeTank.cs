using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_UpgradeTank : MonoBehaviour
{
    [SerializeField] private TankData tankData;

    [SerializeField] private int idTank;

    [SerializeField] private Transform modelTankParent;
    [SerializeField] private Slider[] sliders;
    [SerializeField] private Slider slidersLevel;
    [SerializeField] private TextMeshProUGUI[] textSliders;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private TextMeshProUGUI tankNameText;
    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private Button btnUpgrade;
    [SerializeField] private Button btnLeft;
    [SerializeField] private Button btnRight;
    [SerializeField] private Button btnPlayNow;


    public static Action<int, int> upgradeTankEvent;
    private void Start()
    {
        btnLeft.onClick.AddListener(OnLeft);
        btnRight.onClick.AddListener(OnRight);
        btnPlayNow.onClick.AddListener(OnPlayNow);
        btnUpgrade.onClick.AddListener(OnUpgradeTank);
    }

    private void OnEnable()
    {
        SetIdTank(idTank);
        SetTankData();
        UpdateCanvasUpgradeTank();
    }

    public void SetIdTank(int id)
    {
        idTank = id;
        idTank = Mathf.Clamp(idTank, 0, DataManager.Instance.LocalData.ListTankData.Count - 1);
    }

    private void SetTankData()
    {
        tankData = DataManager.Instance.LocalData.GetTankDataById(idTank);
    }
    private void UpdateCanvasUpgradeTank()
    {
        SetUpTankName();
        SetUpSlider();
        SetUpModelTank();
    }
    private void SetUpSlider()
    {
        int tankLevel = DataManager.Instance.PlayerData.tankLevels[idTank];
        
        sliders[0].maxValue = Constant.dameMaxValue;
        sliders[1].maxValue = Constant.hpMaxValue;
        sliders[2].maxValue = Constant.speedMaxValue;


        sliders[0].value = tankData.dameTank + tankLevel * Constant.dameBonus;
        sliders[1].value = tankData.hpTank + tankLevel * Constant.hpBonus;
        sliders[2].value = tankData.speedTank + tankLevel * Constant.speedBonus;

        textSliders[0].text = (tankData.dameTank + tankLevel * Constant.dameBonus).ToString();
        textSliders[1].text = (tankData.hpTank + tankLevel * Constant.hpBonus).ToString();
        textSliders[2].text = (tankData.speedTank + tankLevel * Constant.speedBonus).ToString();

        textGold.text = (Constant.goldOrin + tankLevel * Constant.goldBonus).ToString();

        slidersLevel.maxValue = Constant.levelMax;
        slidersLevel.value = tankLevel;
        textLevel.text = $"LV.{tankLevel}";
    }
    private void SetUpModelTank()
    {
        foreach (Transform child in modelTankParent)
        {
            Destroy(child.gameObject);
        }
        //sinh ra tank//
        //
        GameObject tankIcon3D = tankData.iconTank3D;
        Instantiate(tankIcon3D, modelTankParent);
    }

    private void SetUpTankName()
    {
        tankNameText.text = tankData.nameTank;
    }

    private void OnUpgradeTank()
    {
        if (DataManager.Instance.PlayerData.tankLevels[idTank] >= Constant.levelMax)
        {
            return;
        }
        int goldOwner = DataManager.Instance.GetPlayerDataGold();
        int price = int.Parse(textGold.text);
        if (goldOwner > price)
        {
            goldOwner = goldOwner - price;
            if (upgradeTankEvent != null)
            {
                upgradeTankEvent(goldOwner ,idTank);
            }
        }

        Canvas_Gold.Instance.UpdateGoldText();
        UpdateCanvasUpgradeTank();
    }

    private void OnPlayNow()
    {
        //
    }

    private void OnLeft()
    {
        int oldIdTank = idTank;
        SetIdTank(idTank - 1);
        List<int> tankStates = DataManager.Instance.PlayerData.tankStates;
        for (int i = idTank; i >= 0; i--)
        {
            if (tankStates[i] != 0)
            {
                SetIdTank(i);
                SetTankData();
                UpdateCanvasUpgradeTank();
                return;
            }
        }
        SetIdTank(oldIdTank);
    }
    private void OnRight()
    {
        int oldIdTank = idTank;
        SetIdTank(idTank + 1);
        List<int> tankStates = DataManager.Instance.PlayerData.tankStates;
        for (int i = idTank; i < tankStates.Count; i++)
        {
            if (tankStates[i] != 0)
            {
                SetIdTank(i);
                SetTankData();
                UpdateCanvasUpgradeTank();
                return;
            }
        }
        SetIdTank(oldIdTank);
    }

    private bool IsTankOwner()
    {
        if (DataManager.Instance.PlayerData.tankStates[idTank] != 0)
        {
            return true;
        }
        return false;
    }
}
