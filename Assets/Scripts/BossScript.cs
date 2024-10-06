using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    GameObject[] enemies;
    public GameObject explosion;
    public int hp = 250;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject.Find("WaveManager").GetComponent<WaveManager>().bossAlive = false;
            foreach (GameObject enemy in enemies){
                GameObject booms;
                booms = Instantiate(explosion, enemy.transform.position, enemy.transform.rotation);
                Destroy(enemy);
            }
            Destroy(GameObject.Find("WaveMember"));

            GameObject boom;
            boom = Instantiate(explosion, transform.position, transform.rotation);
            boom.transform.localScale = new Vector3 (3,3,3);
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
    }
    }
