using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModelRotate : MonoBehaviour
{
    [SerializeField] private Transform modelTankParent;
    [SerializeField] private float angle;
    public GameObject modelTankPrefab;
    void Update()
    {
        transform.Rotate(0, angle, 0);
    }

    private void ChangeModelTank()
    {
        foreach (Transform child in modelTankParent)
        {
            Destroy(child.gameObject);

            Instantiate(modelTankPrefab, modelTankParent);
        }
    }
}
