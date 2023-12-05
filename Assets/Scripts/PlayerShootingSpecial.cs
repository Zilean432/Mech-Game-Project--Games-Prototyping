using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlayerShootingSpecial : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bulletSpecial;
    public Transform bulletTransformSpecial;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public string fireButton;
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
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetKey(fireButton) && canFire)
        {
            canFire = false;
            Instantiate(bulletSpecial, bulletTransformSpecial.position, Quaternion.identity);
        }
    }
}
