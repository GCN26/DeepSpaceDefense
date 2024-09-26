using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int waveNumber = 0;
    public GameObject prefab;

    void Update()
    {
        if (GameObject.Find("WaveMember") != null)
        {

        }
        else
        {
            waveNumber += 1;
            Debug.Log("waveNumber");
            GameObject WaveMember = Instantiate(prefab);
            WaveMember.name = "WaveMember";
            WaveLogic();
        }
    }

    public void WaveLogic()
    {
        if(waveNumber % 3 == 0)
        {
            //upgrade script
            Debug.Log("Upgrade");
            //when upgrade is complete, allow for wave to be spawned
        }
        //if upgrade GUI is not present:
        if(waveNumber % 15 == 0)
        {
            //boss wave
            Debug.Log("Boss Wave");
        }
        else
        {
            //Regular Wave
            Debug.Log("Normal Wave");
        }
    }
}
