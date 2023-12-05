using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float lifeTimer;
    public float damage;
    public float lifeTimerLimit;
    public GameObject hitParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer > lifeTimerLimit)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else 
        {
            if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "EnemyBullet")
                Destroy(gameObject);
        }
    }
}
