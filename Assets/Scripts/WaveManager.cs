using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int waveNumber = 0;
    public GameObject prefab;
    //Spawning Nodes
    public AmNode NodeSpawn1, NodeSpawn2, NodeSpawn3;
    //Middle Nodes
    public AmNode NodeMiddle1, NodeMiddle3;
    //Ending Nodes
    public AmNode NodeEnd1, NodeEnd2, NodeEnd3;
    //Looping Nodes
    public AmNode NodeLoopBL, NodeLoopBR, NodeLoopML, NodeLoopMR, NodeLoopTL, NodeLoopTR;

    //Randomize which pattern will spawn and which paths they will spawn on
    public int randNum;

    //variables to allow for continuous spawning during boss wave
    public int spawnTimer = 90;
    public int spawnTimerTarget = 90;

    void Update()
    {
        if (GameObject.Find("WaveMember") != null)
        {

        }
        else
        {
            waveNumber += 1;
            //Run code based on what wave it is
            //if wave number is 3, activate ui
            //once ui is closed, run wave creation code
            //if wave number is 15, run boss creation code after upgrade
            //with boss active, spawn enemies endlessly.
            WaveLogic();
        }
    }

    public void WaveLogic()
    {
        if (waveNumber % 3 == 0)
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
        }
        Debug.Log("waveNumber");
        randNum = UnityEngine.Random.Range(0, 7);
        SpawnWave(randNum, 0, waveNumber);
        randNum = UnityEngine.Random.Range(0, 7);
        SpawnWave(randNum, 4, waveNumber);
        randNum = UnityEngine.Random.Range(0, 7);
        SpawnWave(randNum, 0, waveNumber);
        randNum = UnityEngine.Random.Range(0, 7);
        SpawnWave(randNum, 8, waveNumber);

    }



    public void SpawnEnemy(int path, int layer)
    {
        int direct = 0;
        if (path == 0) direct = -1; else if (path == 1) direct = 0; else if (path == 2) direct = 1;

        GameObject WaveMember = Instantiate(prefab, new Vector3(5*direct, 11+(layer*2), 0), Quaternion.identity);
        WaveMember.name = "WaveMember";
        AmNode[] nodes = PathSelect(path);
        WaveMember.GetComponent<PathNodeScript>().nodes = nodes;
    }
    public AmNode[] PathSelect(int path)
    {
        if (path == 0)
        {
            AmNode[] nodes = { NodeEnd1, NodeLoopBL, NodeLoopTL, NodeSpawn1 };
            return nodes;
        }
        else if (path == 1)
        {
            AmNode[] nodes = { NodeEnd2, NodeLoopBL, NodeLoopTL, NodeSpawn2 };
            return nodes;
        }
        else if (path == 2)
        {
            AmNode[] nodes = { NodeEnd3, NodeLoopBR, NodeLoopTR, NodeSpawn3 };
            return nodes;
        }
        else if (path == 3)
        {
            AmNode[] nodes = { NodeMiddle1, NodeLoopML, NodeLoopTL, NodeSpawn1 };
            return nodes;
        }
        else if (path == 4)
        {
            AmNode[] nodes = { NodeMiddle3, NodeLoopMR, NodeLoopTR, NodeSpawn3 };
            return nodes;
        }
        else return null;
    }
    public void SpawnWave(int randNum, int addLayer, int waveNumber)
    {
        int layerMulti = (addLayer)*6;

        if (randNum == 0)
        {
            SpawnEnemy(0, 0+addLayer);
            SpawnEnemy(0, 1 + addLayer);
            SpawnEnemy(0, 2 + addLayer);
        }
        else if (randNum == 1)
        {
            SpawnEnemy(1, 0 + addLayer);
            SpawnEnemy(1, 1 + addLayer);
            SpawnEnemy(1, 2 + addLayer);
        }
        else if (randNum == 2)
        {
            SpawnEnemy(2, 0 + addLayer);
            SpawnEnemy(2, 1 + addLayer);
            SpawnEnemy(2, 2 + addLayer);
        }
        else if (randNum == 3)
        {
            //spawn 1 enemy on path 1 and 1 on 3
            SpawnEnemy(0, 0 + addLayer);
            SpawnEnemy(2, 1 + addLayer);
        }
        else if (randNum == 4)
        {
            //spawn 2 enemies on path 1 and 2 on 3
            SpawnEnemy(0, 0 +addLayer);
            SpawnEnemy(2, 0 + addLayer);
            SpawnEnemy(0, 1 + addLayer);
            SpawnEnemy(2, 1 + addLayer);
        }
        else if (randNum == 5)
        {
            SpawnEnemy(0, 0 + addLayer);
            SpawnEnemy(2, 0 + addLayer);
            SpawnEnemy(0, 1 + addLayer);
            SpawnEnemy(2, 1 + addLayer);
            SpawnEnemy(0, 2 + addLayer);
            SpawnEnemy(1, 2 + addLayer);
            SpawnEnemy(2, 2 + addLayer);
        }
        else if (randNum == 6)
        {
            //spawn 1 enemy on path 1 and 1 on 3
            SpawnEnemy(3, 0 + addLayer);
            SpawnEnemy(4, 0 + addLayer);
        }
    }
}
