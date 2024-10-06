using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject self;

    float horizontal;
    float vertical;
    float moveLimit = 0.7f;

    public float moveSpeed = 20.0f;

    public Rigidbody2D bullet;
    public float bulletSpeed = 10;
    public int bulletDamage = 1;
    public int bulletCount = 1;

    public float iFrameTimer = 0;
    public float iFrameTarget = 2;

    public int hp = 3;

    public GameObject explosion;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("space"))
        {
            PlayerAttack();
        }
        if(iFrameTimer <= iFrameTarget)
        {
            iFrameTimer += Time.deltaTime;
        }
        if(iFrameTimer >= iFrameTarget) {
            self.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimit;
            vertical *= moveLimit;

        }
        body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

    public void PlayerAttack()
    {
        if(bulletCount > 10)
        {
            bulletCount = 10;
        }
        if(bulletCount % 2 != 0) {
            SpawnBullet(0);
            //for loop but add 2 each time
            for(float i = 0; i < bulletCount-2; i++)
            {
                SpawnBullet(-(i+1)*.5f);
                SpawnBullet((i + 1) * .5f);
            }
        }
        else
        {
            SpawnBullet(.5f);
            SpawnBullet(-.5f);
            //for loop but add 2 each time
            for (float i = 0; i < bulletCount-2; i++)
            {
                SpawnBullet(-(i + 1) * .5f);
                SpawnBullet((i + 1) * .5f);
            }
        }
    }
    public void SpawnBullet(float dist)
    {
        Vector3 distance = transform.position + new Vector3(dist, 0, 0);
        Rigidbody2D clone;
        clone = Instantiate(bullet, distance, transform.rotation);
        clone.GetComponent<PlayerBulletScript>().speed = bulletSpeed;
        clone.GetComponent<PlayerBulletScript>().damage = bulletDamage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (iFrameTimer >= iFrameTarget)
        {
            if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Asteroid")
            {
                //Destroy, Remove one life, and respawn at origin with iframes
                //try and stop collisions during iframes
                hp -= 1;
                iFrameTimer = 0;
                self.SetActive(true);
                if (hp<=0) {
                    GameObject boom;
                    boom = Instantiate(explosion, transform.position, transform.rotation);
                    Destroy(gameObject); }
            }
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<WaveObject>().hp = 0;
        }
    }
}
