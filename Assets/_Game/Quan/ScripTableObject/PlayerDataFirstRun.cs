using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerDataFirstRun", menuName = "PlayerDataFirstRun")]
public class PlayerDataFirstRun : ScriptableObject
{
    [SerializeField] public PlayerData playerData;



    [Button("SetUpList")]
    private void SetUpList()
    {
        playerData = new PlayerData();
        for (int i = 0; i < DataManager.Instance.LocalData.ListTankData.Count; i++)
        {
            playerData.tankNames.Add((TankName)i);

            if (i == 0)
            {
                playerData.tankStates.Add(2);
            }
            else
            {
                playerData.tankStates.Add(0);

            }
            playerData.tankLevels.Add(0);
        }
    }


}
