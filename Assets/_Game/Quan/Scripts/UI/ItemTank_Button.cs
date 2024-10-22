using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTank_Button : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTank;
    [SerializeField] private Image iconTank;
    [SerializeField] private TextMeshProUGUI priceText;

    [SerializeField] private TextMeshProUGUI dameText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Slider dameSlider;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider speedSlider;

    private int dameMaxValue = 500;
    private int hpMaxValue = 800;
    private int speedMaxValue = 200;

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

    private void SetSliderMaxValue()
    {
        dameSlider.maxValue = dameMaxValue;
        hpSlider.maxValue = hpMaxValue;
        speedSlider.maxValue = speedMaxValue;
    }
}
