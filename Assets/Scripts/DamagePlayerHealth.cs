using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerHealth : MonoBehaviour
{
    public float damage;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
