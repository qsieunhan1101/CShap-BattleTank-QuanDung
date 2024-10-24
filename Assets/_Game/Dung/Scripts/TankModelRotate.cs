using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModelRotate : MonoBehaviour
{
    [SerializeField] private float angle;
    void Update()
    {
        transform.Rotate(0, angle, 0);
    }
}
