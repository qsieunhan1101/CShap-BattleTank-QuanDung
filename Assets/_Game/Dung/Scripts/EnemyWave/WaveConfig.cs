using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public GameObject[] enemyPrefabs; 
    public int[] enemyCounts;
}