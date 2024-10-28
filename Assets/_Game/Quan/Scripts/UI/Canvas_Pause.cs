using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Pause : MonoBehaviour
{
    public void OnContinue()
    {
        Time.timeScale = 1.0f;
    }

    public void OnQuit()
    {
        Time.timeScale = 1.0f;
    }
}
