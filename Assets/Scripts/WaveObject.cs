using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveObject : MonoBehaviour
{
    public int memberOfWave = 0;

    public int shootTimer = 0;
    public int shootTimerTarget = 120;

    public int hp = 5;

    public Rigidbody2D bullet;
    public float bulletSpeed = -10;

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
        shootTimer++;
        if(shootTimer > shootTimerTarget)
        {
            EnemyAttack();
        }
        if(hp <= 0) 
        { 
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
