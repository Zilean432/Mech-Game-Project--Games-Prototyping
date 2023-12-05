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

    //This function gets the health value from the PlayerHealth script, and reduces it by the amount that has been passed through to the damage variable from the bullet object that has collided with the player.
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
