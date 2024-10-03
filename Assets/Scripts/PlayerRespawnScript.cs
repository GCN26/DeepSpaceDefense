using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawnScript : MonoBehaviour
{
    public int resTimer = 0;
    public int resTimerTarget = 120;
    public Rigidbody2D Player;
    //specifically number of respawns
    public int lives = 4;

    public float bulletSpeed = 10;
    public int bulletDamage = 1;
    public int bulletCount = 1;

    public TextMeshProUGUI livesCount;
    public TextMeshProUGUI hpCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesCount.text = "Lives: " + (lives+1);
        if (GameObject.Find("Player") != null)
        {
            hpCount.text = "HP: " + GameObject.Find("Player").GetComponent<PlayerScript>().hp;
        }
        else
        {

                hpCount.text = "HP: " + 0;
        }
        if (GameObject.Find("Player") == null && lives > 0)
        {
            resTimer++;
            if(resTimer >= resTimerTarget)
            {
                resTimer = 0;
                Rigidbody2D clone;
                clone = Instantiate(Player, transform.position, transform.rotation);
                clone.name = "Player";
                clone.gameObject.GetComponent<PlayerScript>().iFrameTimer = 0;
                clone.gameObject.GetComponent<PlayerScript>().bulletSpeed = bulletSpeed;
                clone.gameObject.GetComponent<PlayerScript>().bulletDamage = bulletDamage;
                clone.gameObject.GetComponent<PlayerScript>().bulletCount = bulletCount;
                lives -= 1;
            }
        }
        else if (GameObject.Find("Player") == null && lives == 0)
        {
            //game over
            //display text object and end the game after 5 seconds
        }
        else if (GameObject.Find("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerScript>().bulletSpeed = bulletSpeed;
            GameObject.Find("Player").GetComponent<PlayerScript>().bulletDamage = bulletDamage;
            GameObject.Find("Player").GetComponent<PlayerScript>().bulletCount = bulletCount;
        }
    }
    public void SpeedUpgrade()
    {
        bulletSpeed += 5;
        if (bulletSpeed > 50)
        {
            bulletSpeed = 50;
        }
    }
    public void DamageUpgrade()
    {
        bulletDamage += 1;
    }
    public void CountUpgrade()
    {
        bulletCount += 1;
        if (bulletCount > 7)
        {
            bulletCount = 7;
        }
    }
}
