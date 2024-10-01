using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveObject : MonoBehaviour
{
    public int memberOfWave = 0;

    public int shootTimer = 0;
    public int shootTimerTarget = 90;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //damage the enemy, if hp is 0, kill
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        shootTimer++;
    }
    void EnemyAttack()
    {
        if(shootTimer >= shootTimerTarget)
        {
            shootTimer = 0;

        }
    }
}
