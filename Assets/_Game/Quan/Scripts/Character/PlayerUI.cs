using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Canvas playerUI;

    [SerializeField] private Vector3 uiRotation;
    // Start is called before the first frame update
    void Start()
    {
        playerUI.worldCamera = Camera.main;

        uiRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(uiRotation);
    }
    
}
