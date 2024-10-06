using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManagerScript : MonoBehaviour
{
    public GameObject prefab;
    //Nodes
    public AmNode NodeTo, NodeFreeze;
    public GameObject waveManager;
    public float timer = 0;
    public float target = 2f;
    public int randNum;

    private void Update()
    {
        if (waveManager.GetComponent<WaveManager>().UpgradeMenu.activeSelf == false)
        {

        }
        else
        {
        }
        if (GameObject.Find("Boss"))
        {
            timer += Time.deltaTime;
            if (timer > target)
            {
                timer = 0;
                randNum = UnityEngine.Random.Range(0, 3);
                waveManager.GetComponent<WaveManager>().SpawnBossWave(randNum, (4));
            }
        }
    }

    public void SpawnBoss()
    {
        GameObject Boss = Instantiate(prefab, new Vector3(0, 25, 0), Quaternion.identity);
        Boss.name = "Boss";
        AmNode[] nodes = { NodeTo, NodeFreeze };
        Boss.GetComponent<BossNodeScript>().nodes = nodes;
    }
}
