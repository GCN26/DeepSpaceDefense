using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveObject : MonoBehaviour
{
    public int waveOf = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
