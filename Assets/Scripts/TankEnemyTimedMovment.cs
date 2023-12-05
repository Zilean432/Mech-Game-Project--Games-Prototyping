using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyTimedMovement : MonoBehaviour
{
    public float speed = 1f;
    private float timer;
    public float changeDirectionTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // The following causes the tank enemy to change their movement direction after a certain amount of time.
    void Update()
    {
        float deltaX = speed * Time.deltaTime;
        transform.Translate(deltaX, 0, 0);

        timer += Time.deltaTime;
        if (timer > changeDirectionTime)
        {
            speed = speed * -1;
            timer = 0;
        }

    }


}
