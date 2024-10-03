using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    Rigidbody2D body;
    public Transform EndPoint;

    public float speed;
    public int damage;

    public GameObject ResManager;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ResManager = GameObject.Find("PlayerRespawnManager");
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(0,speed);
        damage = ResManager.GetComponent<PlayerRespawnScript>().bulletDamage;
    }

    //destroy bullet when touching endpoint
    //destroy enemy bullet
    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "End"|| collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
       if(collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
