using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGame : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(sceneName: "Game");
    }
    public void CloseQuit()
    {
        Application.Quit();
    }
}
