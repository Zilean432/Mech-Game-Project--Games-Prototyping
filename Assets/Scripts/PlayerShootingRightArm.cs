using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingRight : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bulletRight;
    public Transform bulletTransformRight;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        //These 4 lines of code allow the arm of the player to point towards the mouse cursor's current position on the screen at any given moment.
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        //The following manages the delay between when the player can next shoot a bullet, if they have already shot a bullet and the 'canFire' variable has been set to false.
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        //The following allows the player to shoot a bullet using the left mouse button, and sets the 'canFire' variable to false.
        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bulletRight, bulletTransformRight.position, Quaternion.identity);
        }
    }
}
