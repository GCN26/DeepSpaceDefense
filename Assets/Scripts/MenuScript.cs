using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject menu;
    
    public bool Paused = false;

    private void Start()
    {
        menu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape") && menu != null) 
        {
            ButtonPress();
        }
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0.0f;
        Paused = true;
    }
    public void Continue()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
        Paused = false;
    }

    public void ButtonPress()
    {
        if (Paused == true)
        {
            Continue();
        }
        else if (Paused == false)
        {
            Pause();
        }
    }
}
