using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimit = 0.7f;

    public float moveSpeed = 20.0f;

    public Rigidbody2D bullet;
    public float bulletSpeed = 10;
    public int bulletDamage = 1;
    public int bulletCount = 1;


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

    public void CountUpgrade()
    {
        bulletCount += 1;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            //Destroy, Remove one life, and respawn at origin with iframes
            Destroy(gameObject);
        }
    }
}
