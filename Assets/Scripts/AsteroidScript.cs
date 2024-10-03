using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public int hp = 5;
    public int waveNumber;
    public GameObject waveManager;

    private void Start()
    {
        waveNumber = waveManager.gameObject.GetComponent<WaveManager>().waveNumber;
    }
    void Update()
    {
        //create asteroid object and have it travel to a node
        //once it reaches a node, destroy it
        //any enemy objects and bullets instantly die upon collision
        //player destroys object after taking damage rather than dying instantly
        //spawns once every 2 waves post 1st upgrade, called 600 frames after enemies
        //destroyed after wave ends or reaches node
        if(hp < 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= collision.gameObject.GetComponent<PlayerBulletScript>().damage;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
