using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletPos;
    private float timer;
    private float ammo;
    public float maxAmmo;
    public float timerLimit;
    public float reloadTimerLimit;
    private bool canShoot;
    private GameObject player;
    private float reloadTimer;

    void Start()
    {
        canShoot = true;
        ammo = maxAmmo;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (canShoot == true && distance < 10)
        {
            timer += Time.deltaTime;
            
            if (timer > timerLimit)
            {
                timer = 0;
                Shoot();
                ammo = ammo - 1;
            }
        }
        
        if (canShoot == false)
            {
                reloadTimer += Time.deltaTime;

                if (reloadTimer >= reloadTimerLimit)
                {
                    ammo = maxAmmo;
                }
            }
        

        if (ammo <= 0)
        {
            canShoot = false;
        }

        else
        {
            if (ammo >= maxAmmo)
            {
                canShoot = true;
                reloadTimer = 0;
            }
        }

    }

    void Shoot()
    {
        Instantiate(Bullet, BulletPos.position, Quaternion.identity);
    }
}
