using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    Rigidbody2D body;
    public Transform EndPoint;

    public float speed;
    public int damage;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(0,speed * -1);

    }

    //destroy bullet when touching endpoint, player, or player bullet
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("End") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
