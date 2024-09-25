using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGame : MonoBehaviour
{
    public string SceneName;

    private void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneName: SceneName);
    }
}
