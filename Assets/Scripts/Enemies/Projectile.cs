using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float lifetime = 2f;
    private float aliveTime = 0f;

    // Update is called once per frame
    void Update()
    {
        aliveTime += Time.deltaTime;
        if(aliveTime > lifetime)
            Destroy(gameObject);
    }
}
