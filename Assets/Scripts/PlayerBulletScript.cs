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

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(0,speed);

    }

    //destroy bullet when touching endpoint
    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "End")
        {
            Destroy(gameObject);
        }
    }
}
