using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

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

        //The following allows the enemy to shoot a bullet if the player is within a certain range of them, and if the enemy's ammo count is above 0.
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
        
        //The following sets a delay on the enemy's next shot and restores their ammo to full once this delay is over, allowing them to shoot again.
        if (canShoot == false)
            {
                reloadTimer += Time.deltaTime;

                if (reloadTimer >= reloadTimerLimit)
                {
                    ammo = maxAmmo;
                }
            }
        
        //The following prevents the enemy from being able to shoot while their ammo is depleted.
        if (ammo <= 0)
        {
            canShoot = false;
        }

        //The following allows the enemy to shoot once again after their ammo has been refilled.
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
