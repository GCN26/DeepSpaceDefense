using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundKillNode : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BG")
        {
            Destroy(collision.gameObject);
        }
    }
}
