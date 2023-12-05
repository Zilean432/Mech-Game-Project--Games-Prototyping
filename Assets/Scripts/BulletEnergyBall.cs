using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletEnergyBall : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    private float lifeTimer;
    public float damage;
    public float baseSize;
    private float size;
    private float hitCooldown;
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
        transform.localScale = new Vector3(baseSize, baseSize, 1f);
    }

   
    void Update()
    {
        lifeTimer += Time.deltaTime;

        //The following 2 lines allow the energy ball projectile to progressively grow bigger from it's starting size the longer it's alive.
        size = lifeTimer + baseSize;
        transform.localScale = new Vector3(size, size, 1f);

        if (lifeTimer >= 3)
        {
            Destroy(gameObject);
        }

        if (hitCooldown < 0.5)
        {
            hitCooldown += Time.deltaTime;
        }
    }

    //The following allows the energy ball projectile to deal damage multiple times to the same enemy, based on how long or short the hit cooldown 
    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy" && hitCooldown >= 0.5)
        {
            other.gameObject.GetComponent<EnemyHealth>().health -= damage;
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            hitCooldown = 0;
        }
    }
}
