using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemTank_Button : MonoBehaviour
{
    [SerializeField] private int idTank;
    [SerializeField] private Button btnSelf;
    [SerializeField] private GameObject buyTankUI;

    [SerializeField] private TextMeshProUGUI nameTank;
    [SerializeField] private Image iconTank;
    [SerializeField] private TextMeshProUGUI priceText;

    [SerializeField] private TextMeshProUGUI dameText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Slider dameSlider;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider speedSlider;

    public int IdTank => idTank;
    private void Start()
    {
        btnSelf.onClick.AddListener(OnSelf);
    }

    private void OnSelf()
    {
        buyTankUI.GetComponent<Canvas_BuyTank>().SetIdTank(idTank);
        buyTankUI.gameObject.SetActive(true);
    }
    public void SetUpItemUI(string name, Sprite icon, int price, int dame, int hp, int speed)
    {
        nameTank.text = name;
        iconTank.sprite = icon;
        priceText.text = price.ToString();

        dameText.text = dame.ToString();
        hpText.text = hp.ToString();
        speedText.text = speed.ToString();

        SetSliderMaxValue();
        dameSlider.value = dame;
        hpSlider.value = hp;
        speedSlider.value = speed;
    }

    public void SetBuyTankUIGameObject(GameObject newGameobject)
    {
        buyTankUI = newGameobject;
    }
    public void SetIdTank(int id)
    {
        idTank = id;
    }

    private void SetSliderMaxValue()
    {
        dameSlider.maxValue = Constant.dameMaxValue;
        hpSlider.maxValue = Constant.hpMaxValue;
        speedSlider.maxValue = Constant.speedMaxValue;
    }
}
