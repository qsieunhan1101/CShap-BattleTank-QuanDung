using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_BuyTank : MonoBehaviour
{
    [SerializeField] private TankData tankData;

    [SerializeField] private int idTank;
    [SerializeField] private Transform modelTankParent;
    [SerializeField] private Slider[] sliders;
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private TextMeshProUGUI tankNameText;
    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private Button btnBuy;


    [SerializeField] private Canvas_Gold canvas_Gold;


    public static Action<int, int> buyTankEvent;
    private void Start()
    {
        btnBuy.onClick.AddListener(OnBuy);
    }
    private void OnEnable()
    {
        SetTankData();
        UpdateCanvasBuyTank();
    }

    public void SetIdTank(int id)
    {
        idTank = id;
    }

    private void SetTankData()
    {
        tankData = DataManager.Instance.LocalData.GetTankDataById(idTank);
    }
    private void UpdateCanvasBuyTank()
    {
        SetUpModelTank();
        SetUpSlider();
        SetUpTankName();
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
    private void SetUpSlider()
    {
        sliders[0].maxValue = Constant.dameMaxValue;
        sliders[1].maxValue = Constant.hpMaxValue;
        sliders[2].maxValue = Constant.speedMaxValue;


        sliders[0].value = tankData.dameTank;
        sliders[1].value = tankData.hpTank;
        sliders[2].value = tankData.speedTank;

        texts[0].text = tankData.dameTank.ToString();
        texts[1].text = tankData.hpTank.ToString();
        texts[2].text = tankData.speedTank.ToString();

        textGold.text = tankData.priceTank.ToString();
    }

    private void SetUpTankName()
    {
        tankNameText.text = tankData.nameTank;
    }

    private void OnBuy()
    {
        int goldOwner = DataManager.Instance.GetPlayerDataGold();
        int price = int.Parse(textGold.text);
        if (goldOwner > price)
        {
            goldOwner = goldOwner - price;
            if (buyTankEvent != null)
            {
                buyTankEvent(goldOwner, idTank);
            }
            canvas_Gold.UpdateGoldText();
            gameObject.SetActive(false);
        }
    }
}
