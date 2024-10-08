using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OtherMenu : MonoBehaviour
{
    public TextMeshProUGUI menuText;
    public GameObject menuButton;
    public GameObject mainButtons;

    public void Controls()
    {
        mainButtons.SetActive(false);
        menuButton.SetActive(true);
        menuText.gameObject.SetActive(true);
        menuText.text = "Arrow Keys or WASD to move\nSpace to shoot\nEscape to pause";
    }
    public void Credits()
    {
        mainButtons.SetActive(false);
        menuButton.SetActive(true);
        menuText.gameObject.SetActive(true);
        menuText.text = "Code and Art by Gibby S\r\nExplosion Gif from Deltarune by Toby Fox";
    }

    public void MainMenu()
    {
        menuButton.SetActive(false);
        menuText.gameObject.SetActive(false);
        mainButtons.SetActive(true);
    }
}
