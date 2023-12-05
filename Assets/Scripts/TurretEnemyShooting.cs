using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class TurretEnemyShooting : MonoBehaviour
{
    public GameObject turretBullet;
    public Transform turretBulletPos;
    private float timer;
    private float ammo;
    private bool canShoot;
    private GameObject player;
    private float reloadTimer;

    void Start()
    {
        canShoot = true;
        ammo = 3;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (canShoot == true && distance < 10)
        {
            timer += Time.deltaTime;
            
            if (timer > 0.2)
            {
                timer = 0;
                Shoot();
                ammo = ammo - 1;
            }
        }
        
        if (canShoot == false)
            {
                reloadTimer += Time.deltaTime;

                if (reloadTimer >= 1.5)
                {
                    ammo = 3;
                }
            }
        

        if (ammo <= 0)
        {
            canShoot = false;
        }

        else
        {
            if (ammo >= 3)
            {
                canShoot = true;
                reloadTimer = 0;
            }
        }

    }

    void Shoot()
    {
        Instantiate(turretBullet, turretBulletPos.position, Quaternion.identity);
    }
}
