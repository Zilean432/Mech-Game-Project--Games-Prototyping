using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitParticleScript : MonoBehaviour
{
    private float lifeTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= 0.3)
        {
            Destroy(gameObject);
        }
    }
}
