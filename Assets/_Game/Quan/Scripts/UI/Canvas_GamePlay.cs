using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_GamePlay : MonoBehaviour
{

    public void OnPause()
    {
        Time.timeScale = 0;
    }
}
