using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
