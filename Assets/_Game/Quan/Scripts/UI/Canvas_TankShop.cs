using System.Collections.Generic;
using UnityEngine;

public class Canvas_TankShop : MonoBehaviour
{
    [SerializeField] private Transform itemTankShop_Parent;
    [SerializeField] private GameObject itemTankShop_Button;


    [SerializeField] private GameObject buyTankUI;


    private void Start()
    {
        SpawnItemTankShop_Button();
    }


    private void OnEnable()
    {
        Canvas_BuyTank.buyTankEvent += DestroyItemById;
    }

    private void SpawnItemTankShop_Button()
    {
        List<TankData> listTankData = DataManager.Instance.LocalData.ListTankData;
        foreach (Transform child in itemTankShop_Parent)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < DataManager.Instance.LocalData.ListTankData.Count; i++)
        {
            if (DataManager.Instance.PlayerData.tankStates[i] == 0)
            {

                TankData tankData = listTankData[i];
                GameObject item = Instantiate(itemTankShop_Button, itemTankShop_Parent);
                ItemTank_Button itemTank_Button = item.GetComponent<ItemTank_Button>();
                itemTank_Button.SetUpItemUI(tankData.nameTank, tankData.iconTank, tankData.priceTank, tankData.dameTank, tankData.hpTank, tankData.speedTank);
                itemTank_Button.SetBuyTankUIGameObject(buyTankUI);
                itemTank_Button.SetIdTank(i);
            }
        }
    }

    private void DestroyItemById(int emty, int id)
    {
        foreach (Transform child in itemTankShop_Parent)
        {
            if (child.GetComponent<ItemTank_Button>().IdTank == id)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
