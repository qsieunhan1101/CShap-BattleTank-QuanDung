using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInit : MonoBehaviour
{

    float timeDestroy = 2f;
    void OnEnable()
    {
        Destroy(this.gameObject, timeDestroy);
    }

}
