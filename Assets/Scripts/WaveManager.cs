using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
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
    //Boss Wave Nodes
    public AmNode NodeBossWave, NodeKill;

    //Randomize which pattern will spawn and which paths they will spawn on
    public int randNum;

    //variables to allow for continuous spawning during boss wave
    public int spawnTimer = 90;
    public int spawnTimerTarget = 90;

    bool waveCall = false;

    public GameObject UpgradeMenu;

    public GameObject ResManager;

    public GameObject BossManager;

    public GameObject MidMenu;
    public TextMeshProUGUI MidMenuText;

    public GameObject PauseMenu;

    public int level;

    public TextMeshProUGUI WaveNumberDisplay;

    public bool bossAlive = true;

    float endTimer = 0;
    float endTarget = 1;

    private void Start()
    {
        UpgradeMenu.SetActive(false);
    }

    void Update()
    {
        //This should eventually be replaced with a counter that takes every instance of the object
        //then calls the code rather than when theres no wave members
        //after each wave should be a brief period of time with text on screen that says "Wave Complete"
        if (waveCall == true && bossAlive == true)
        {
            waveCall = false;
            UpgradeCheck();
            waveNumber += 1;
            if(waveNumber % 5 == 0 && waveNumber != 0)
            {
                level += 1;
            }
            WaveLogic();    
        }
        else if (bossAlive == true)
        {
            if(GameObject.Find("WaveMember") == null && UpgradeMenu.activeSelf == false && GameObject.Find("Boss") == null)
            {
                waveCall = true;
            }
        }
        else if (bossAlive == false)
        {
            Time.timeScale = 1;
            Destroy(PauseMenu);
            //end game
            endTimer += Time.deltaTime;
            if(endTimer > endTarget)
            {
                MidMenuText.text = "VICTORY!";
                MidMenu.SetActive(true);
            }
        }
    }

    public void WaveLogic()
    {
        //if upgrade GUI is not present OR game is not over
        if (UpgradeMenu.activeSelf == false)
        {
            if (waveNumber % 16 == 0)
            {
                WaveNumberDisplay.text = "Boss Wave";
                //boss wave
                Debug.Log("Boss Wave");
                BossManager.GetComponent<BossManagerScript>().SpawnBoss();
                for (int i = 0; i < level + 1; i++)
                {
                    //Enemy Spawning continuous
                    randNum = UnityEngine.Random.Range(17, 20);
                    SpawnWave(randNum, (i * 4));
                }
                //add variable that stops the game after the boss is defeated rather than spawning a new wave
            }
            else
            {
                WaveNumberDisplay.text = "Wave #" + waveNumber.ToString();
                for (int i = 0; i < level+1; i++)
                {
                    randNum = UnityEngine.Random.Range(0, 14);
                    SpawnWave(randNum, (i*4));
                }
            }
        }
    }
    public void UpgradeCheck()
    {
        if (waveNumber % 3 == 0 && waveNumber != 0)
        {
            UpgradeMenu.SetActive(true);
            ResManager.gameObject.GetComponent<PlayerRespawnScript>().lives += 1;
        }
    }



    public void SpawnEnemy(int path, int layer, int level)
    {
        int direct = 0;
        if (path == 0) direct = -1; else if (path == 1) direct = 0; else if (path == 2) direct = 1;

        GameObject WaveMember = Instantiate(prefab, new Vector3(5*direct, 11+(layer*2), 0), Quaternion.identity);
        WaveMember.name = "WaveMember";
        AmNode[] nodes = PathSelect(path);
        WaveMember.GetComponent<PathNodeScript>().nodes = nodes;
        WaveMember.GetComponent<WaveObject>().hp = 1+level;
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
        else if (path == 5)
        {
            AmNode[] nodes = { NodeEnd1, NodeBossWave, NodeKill };
            return nodes;
        }
        else if (path == 6)
        {
            AmNode[] nodes = { NodeEnd2, NodeBossWave, NodeKill };
            return nodes;
        }
        else if (path == 7)
        {
            AmNode[] nodes = { NodeEnd3, NodeBossWave, NodeKill };
            return nodes;
        }
        else return null;
    }
    public void SpawnWave(int randNum, int addLayer)
    {

        if (randNum == 0)
        {
            SpawnEnemy(0, 2 + addLayer,level);
            SpawnEnemy(1, 2 + addLayer, level);
            SpawnEnemy(2, 2 + addLayer, level);
            SpawnEnemy(0, 1 + addLayer, level);
            SpawnEnemy(1, 1 + addLayer, level);
            SpawnEnemy(2, 1 + addLayer, level);
            SpawnEnemy(0, 0 + addLayer, level);
            SpawnEnemy(1, 0 + addLayer, level);
            SpawnEnemy(2, 0 + addLayer, level);
            SpawnEnemy(3, 2 + addLayer, level);
            SpawnEnemy(4, 2 + addLayer, level);
            SpawnEnemy(3, 1 + addLayer,level);
            SpawnEnemy(4, 1 + addLayer,level);
        }
        else if (randNum == 1)
        {
            SpawnEnemy(0, 2 + addLayer, level);
            SpawnEnemy(0, 1 + addLayer, level);
            SpawnEnemy(0, 0 + addLayer, level);
        }
        else if (randNum == 2)
        {
            SpawnEnemy(1, 2 + addLayer, level);
            SpawnEnemy(1, 1 + addLayer, level);
            SpawnEnemy(1, 0 + addLayer, level);
        }
        else if (randNum == 3)
        {
            SpawnEnemy(2, 2 + addLayer, level);
            SpawnEnemy(2, 1 + addLayer, level);
            SpawnEnemy(2, 0 + addLayer, level);
        }
        else if (randNum == 4)
        {
            SpawnEnemy(3, 2 + addLayer, level);
            SpawnEnemy(4, 2 + addLayer, level);
            SpawnEnemy(3, 1 + addLayer, level);
            SpawnEnemy(4, 1 + addLayer, level);
        }
        else if (randNum == 5)
        {
            SpawnEnemy(0, 2 + addLayer, level);
            SpawnEnemy(0, 1 + addLayer, level);
            SpawnEnemy(0, 0 + addLayer, level);
            SpawnEnemy(2, 2 + addLayer, level);
            SpawnEnemy(2, 1 + addLayer, level);
            SpawnEnemy(2, 0 + addLayer, level);
        }
        else if (randNum == 6)
        {
            SpawnEnemy(0, 1 + addLayer, level);
            SpawnEnemy(2, 1 + addLayer, level);
            SpawnEnemy(3, 2 + addLayer, level);
            SpawnEnemy(4, 2 + addLayer, level);
            SpawnEnemy(3, 1 + addLayer, level);
            SpawnEnemy(4, 1 + addLayer, level);
        }
        else if (randNum == 7)
        {
            SpawnEnemy(0, 2 + addLayer, level);
            SpawnEnemy(1, 2 + addLayer, level);
            SpawnEnemy(2, 2 + addLayer, level);
            SpawnEnemy(0, 1 + addLayer, level);
            SpawnEnemy(2, 1 + addLayer, level);
            SpawnEnemy(0, 0 + addLayer, level);
            SpawnEnemy(2, 0 + addLayer, level);
        }
        else if (randNum == 8)
        {
            SpawnEnemy(0, 2 + addLayer, level);
            SpawnEnemy(2, 2 + addLayer, level);
            SpawnEnemy(1, 1 + addLayer, level);
            SpawnEnemy(0, 0 + addLayer, level);
            SpawnEnemy(2, 0 + addLayer, level);
        }
        else if (randNum == 9)
        {
            SpawnEnemy(0, 2 + addLayer, level);
            SpawnEnemy(2, 2 + addLayer, level);
            SpawnEnemy(0, 0 + addLayer, level);
            SpawnEnemy(2, 0 + addLayer, level);
        }
        else if (randNum == 10)
        {
            SpawnEnemy(0, 2 + addLayer, level);
            SpawnEnemy(1, 1 + addLayer, level);
            SpawnEnemy(2, 0 + addLayer, level);
        }
        else if (randNum == 11)
        {
            SpawnEnemy(1,2+addLayer,level);
            SpawnEnemy(3,2+addLayer,level);
            SpawnEnemy(4,2+addLayer,level);
            SpawnEnemy(0,1+addLayer,level);
            SpawnEnemy(2,1+addLayer,level);
            SpawnEnemy(1,0+addLayer,level);
        }
        else if (randNum == 12)
        {
            SpawnEnemy(1, 2 + addLayer, level);
            SpawnEnemy(3, 2 + addLayer, level);
            SpawnEnemy(4, 2 + addLayer, level);
            SpawnEnemy(1, 1 + addLayer, level);
            SpawnEnemy(1, 0 + addLayer, level);
        }
        else if (randNum == 13)
        {
            SpawnEnemy(0, 2 + addLayer, level);
            SpawnEnemy(1, 2 + addLayer, level);
            SpawnEnemy(2, 2 + addLayer, level);
            SpawnEnemy(0, 1 + addLayer, level);
            SpawnEnemy(2, 1 + addLayer, level);
            SpawnEnemy(0, 0 + addLayer, level);
            SpawnEnemy(1, 0 + addLayer, level);
            SpawnEnemy(2, 0 + addLayer, level);
        }
        else if (randNum == 17)
        {
            SpawnEnemy(5, 5 + addLayer, level);
            SpawnEnemy(5, 1 + addLayer, level);
            SpawnEnemy(5, 2 + addLayer, level);
        }
        else if (randNum == 18)
        {
            SpawnEnemy(6, 0 + addLayer, level);
            SpawnEnemy(6, 1 + addLayer, level);
            SpawnEnemy(6, 2 + addLayer, level);
        }
        else if (randNum == 19)
        {
            SpawnEnemy(7, 0 + addLayer, level);
            SpawnEnemy(7, 1 + addLayer, level);
            SpawnEnemy(7, 2 + addLayer, level);
        }
        // Enemies can spawn in one of 13 grid spaces
        // (-2,2) (-1,2) (0,2) (1,2) (2,2)
        // (-2,1) (-1,1) (0,1) (1,1) (2,1)
        //        (-1,0) (0,0) (1,0)

        // (-1,2) SpawnEnemy(0,2+addLayer,level);
        // (0,2) SpawnEnemy(1,2+addLayer,level);
        // (1,2) SpawnEnemy(2,2+addLayer,level);

        // (-1,1) SpawnEnemy(0,1+addLayer,level);
        // (0,1) SpawnEnemy(1,1+addLayer,level);
        // (1,1) SpawnEnemy(2,1+addLayer,level);

        // (-1,0) SpawnEnemy(0,0+addLayer,level);
        // (0,0) SpawnEnemy(1,0+addLayer,level);
        // (1,0) SpawnEnemy(2,0+addLayer,level);

        //(-2,2) SpawnEnemy(3,2+addLayer,level);
        //(2,2) SpawnEnemy(4,2+addLayer,level);

        //(-2,1) SpawnEnemy(3,1+addLayer,level);
        //(2,1) SpawnEnemy(4,1+addLayer,level);

        


    }
}
