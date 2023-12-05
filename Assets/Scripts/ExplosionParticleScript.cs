using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticleScript : MonoBehaviour
{
    private float lifeTimer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= 0.5)
        {
            Destroy(gameObject);
        }
    }
}
