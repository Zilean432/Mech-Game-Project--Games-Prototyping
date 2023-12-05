using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float deltaY= speed * Time.deltaTime;
        timer += Time.deltaTime;
        transform.Translate(0, deltaY, 0);

        if (timer >= 1.5)
        {
            timer = 0;
            speed = speed * -1;
        }
    }

}
