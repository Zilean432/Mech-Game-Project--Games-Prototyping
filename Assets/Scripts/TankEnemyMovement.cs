using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyMovement : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = speed * Time.deltaTime;
        transform.Translate(deltaX, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EnemyPatrolBoundary")
        {
            speed = speed * -1;
        }


    }
}
