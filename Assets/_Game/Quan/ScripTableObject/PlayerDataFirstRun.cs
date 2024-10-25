using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerDataFirstRun", menuName = "PlayerDataFirstRun")]
public class PlayerDataFirstRun : ScriptableObject
{
    [Header("Initialize")]
    [SerializeField] private int gold;
    [SerializeField] private int levelTank;
    [SerializeField] private int levelMap;
    [SerializeField] private int stateTank;

    [Header("PlayerData")]
    [SerializeField] public PlayerData playerData;



    [Button("SetUpList")]
    private void SetUpList()
    {
        playerData = new PlayerData();
        playerData.gold = gold;
        playerData.levelMap = levelMap;

        for (int i = 0; i < DataManager.Instance.LocalData.ListTankData.Count; i++)
        {
            playerData.tankNames.Add((TankName)i);

            if (i == 0)
            {
                playerData.tankStates.Add(2);
            }
            else
            {
                playerData.tankStates.Add(stateTank);

            }
            playerData.tankLevels.Add(levelTank);
        }
    }


}
