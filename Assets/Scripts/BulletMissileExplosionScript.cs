using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMissileExplosionScript : MonoBehaviour
{
    public float baseSize;
    private float size;
    private float hitCooldown;
    public GameObject hitParticle;
    private float lifeTimer;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(baseSize, baseSize, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;

        //The following 2 lines allow the explosion to progressively grow bigger from it's starting size the longer it's alive.
        size = (lifeTimer + baseSize) * 1.5f;
        transform.localScale = new Vector3(size, size, 1f);

        if (hitCooldown < 0.5)
        {
            hitCooldown += Time.deltaTime;
        }

        if (lifeTimer >= 3)
            Destroy(gameObject);
    }

    //The following allows the explosion to deal damage multiple times to the same enemy, based on how long or short the hit cooldown 
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
