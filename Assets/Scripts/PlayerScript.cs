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
        Rigidbody2D clone;
        clone = Instantiate(bullet, transform.position, transform.rotation);
    }
}
