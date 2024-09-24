using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int waveNumber = 0;

    void Update()
    {
        if (GameObject.Find("WaveMember") != null)
        {

        }
        else
        {
            waveNumber += 1;
            Debug.Log("waveNumber");
        }
    }
}
