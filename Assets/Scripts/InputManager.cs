using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public bool isPaused;

    //Pause Window
    public GameObject pause_window;
    public GameObject option_window;

    
    public void pauseON()
    {
        isPaused = true;
        pause_window.SetActive(true);
        Time.timeScale = 0f;
    }
    public void pauseOFF()
    {
        isPaused = false;
        pause_window.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void options()
    {
        isPaused = true;
        option_window.SetActive(true);
    }

    public void optionDone()
    {
        isPaused = true;
        option_window.SetActive(false);
    }

}
