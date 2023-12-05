using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletRapidScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    private float lifeTimer;
    public float damage;
    public float health;
    public GameObject hitParticle;

    //This is the same code snippet present on all of the bullet types, makes the bullets move towards and be pointed at the direction of the mouse cursor.
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

   
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= 3)
        {
            Destroy(gameObject);
        }

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().health -= damage;
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        else
        {

            if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet" && other.gameObject.tag != "EnemyBullet")
            {
                Destroy(gameObject);
            }
        }

        //This code, combined with the destroy function in the 'update' section, allows the bullet to pass through and destroy a certain number of enemy bullets before it is destroyed itself.
        if (other.gameObject.tag == "EnemyBullet")
        {
            health -= 1;
        }
    }
}
