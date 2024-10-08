using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public int hp = 10;
    public int waveNumber;

    public GameObject explosion;

    void Update()
    {
        if(hp <= 0)
        {
            GameObject boom;
            boom = Instantiate(explosion, transform.position, transform.rotation);
            boom.transform.localScale = new Vector3(2, 2, 2);
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
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<WaveObject>().hp = 0;
        }
        else if (collision.gameObject.tag == "Player")
        {
            hp = 0;
        }
    }
}
