using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ExplosionAnim : MonoBehaviour
{
    public float timer = 0;
    public float target = 1f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= target)
        {
            Destroy(gameObject);
        }
    }
}
