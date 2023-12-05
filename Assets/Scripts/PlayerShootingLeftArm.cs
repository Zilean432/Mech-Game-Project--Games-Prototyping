using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingLeft : MonoBehaviour
{
    //This script is a replica of the right arm player shooting script, with the only difference being that it uses the right mouse button to shoot rather than the left one.
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bulletLeft;
    public Transform bulletTransformLeft;
    public bool canFire;
    private float timer;
    public float timeBetweenFiringLeft;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiringLeft)
            {
                canFire = true;
                timer = 0;
            }
        }
        if(Input.GetMouseButton(1) && canFire)
        {
            canFire = false;
            Instantiate(bulletLeft, bulletTransformLeft.position, Quaternion.identity);
        }
    }
}
