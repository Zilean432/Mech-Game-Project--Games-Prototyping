using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthItem;
    public GameObject explosionParticle;
    private Rigidbody2D rb;
    private int dropChance;


    void Start()
    {
        maxHealth = health;
    }

    
    void Update()
    {
        if (health <= 0)
        {
            int dropChance = Random.Range(1, 100);

            if (dropChance > 50)
            {
                Instantiate(healthItem, transform.position, Quaternion.identity);
            }
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
