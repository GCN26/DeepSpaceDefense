using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WaveObject : MonoBehaviour
{
    public int memberOfWave = 0;

    public float shootTimer = 0;
    public float shootTimerTarget = 2;

    public int hp = 5;

    public Rigidbody2D bullet;
    public float bulletSpeed = -10;

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= collision.gameObject.GetComponent<PlayerBulletScript>().damage;
        }
        if (collision.gameObject.tag == "Asteroid")
        {
            hp -= 5;
        }
    }

    private void Update()
    {
        shootTimer += Time.deltaTime;
        if(shootTimer > shootTimerTarget)
        {
            EnemyAttack();
            shootTimer = 0;
        }
        if(hp <= 0) 
        {
            GameObject boom;
            boom = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject); 
        }
    }
    public void EnemyAttack()
    {
        shootTimer = 0;
        Rigidbody2D clone;
        clone = Instantiate(bullet, transform.position, transform.rotation);
        clone.GetComponent<PlayerBulletScript>().speed = bulletSpeed;
    }
}
