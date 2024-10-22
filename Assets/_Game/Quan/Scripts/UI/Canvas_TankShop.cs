using System.Collections.Generic;
using UnityEngine;

public class Canvas_TankShop : MonoBehaviour
{
    [SerializeField] private Transform itemTankShop_Parent;
    [SerializeField] private GameObject itemTankShop_Button;



    private void Start()
    {
        SpawnItemTankShop_Button();
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
            TankData tankData = listTankData[i];
            GameObject item = Instantiate(itemTankShop_Button, itemTankShop_Parent);
            item.GetComponent<ItemTank_Button>().SetUpItemUI(tankData.nameTank, tankData.iconTank, tankData.priceTank, tankData.dameTank, tankData.hpTank, tankData.speedTank);
        }
    }

}
