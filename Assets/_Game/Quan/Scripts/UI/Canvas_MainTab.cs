using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_MainTabs : MonoBehaviour
{
    [SerializeField] private Transform mainMenuUI;

    private void OnEnable()
    {
        if (mainMenuUI != null)
        {
            mainMenuUI.gameObject.SetActive(true);
        }
    }
}
