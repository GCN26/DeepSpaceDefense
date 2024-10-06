using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AsteroidManagerScript : MonoBehaviour
{
    public GameObject prefab;
    //Spawning Nodes
    public AmNode NodeSpawn1, NodeSpawn2;
    //End Nodes
    public AmNode NodeEnd1, NodeEnd2, NodeEnd3, NodeKill;
    public GameObject waveManager;

    public float spawnTimer = 0;
    public float spawnTimerTarget = 10;


    private void Update()
    {
        if (waveManager.GetComponent<WaveManager>().UpgradeMenu.activeSelf == false && waveManager.GetComponent<WaveManager>().bossAlive == true)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnTimerTarget)
            {
                spawnTimer = 0;
                var randNum = Random.Range(0, 4);
                SpawnAsteroid(randNum);
            }
        }
        else
        {
            Destroy(GameObject.Find("Asteroid"));
        }
    }

    public void SpawnAsteroid(int path)
    {
        var direct = 0;
        if(path == 1 || path == 0) { direct = -20; }
        if(path == 2 || path == 3) { direct = 20; }
        GameObject Asteroid = Instantiate(prefab, new Vector3(direct, 25, 0), Quaternion.identity);
        Asteroid.name = "Asteroid";
        AmNode[] nodes = PathSelect(path);
        Asteroid.GetComponent<AsteroidNodeScript>().nodes = nodes;
    }

    public AmNode[] PathSelect(int path)
    {
        if (path == 0)
        {
            AmNode[] nodes = { NodeSpawn1, NodeEnd3, NodeKill };
            return nodes;
        }
        else if (path == 1)
        {
            AmNode[] nodes = { NodeSpawn1, NodeEnd2, NodeKill };
            return nodes;
        }
        else if (path == 2)
        {
            AmNode[] nodes = { NodeSpawn2, NodeEnd1, NodeKill };
            return nodes;
        }
        else if (path == 3)
        {
            AmNode[] nodes = { NodeSpawn2, NodeEnd2, NodeKill };
            return nodes;
        }
        else return null;
    }
    }
