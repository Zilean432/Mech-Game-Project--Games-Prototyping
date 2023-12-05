using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundPlayerMovement : MonoBehaviour
{
    //This script is mostly the same as the 'FlyingPlayerMovement' script, minus the ability to fly in the air.
    public float moveSpeed = 3f;
    public float jumpForce = 4f;
    public float maxEnergy = 100f;
    public float energyUsage = 15f;
    public float energyRegen = 10f;
    public string left;
    public string right;
    public string up;
    public string down;
    public string boost;
    public Text counterText;

    private bool isGrounded;
    private bool isBoosting;
    private float energy;
    private Rigidbody2D rb;
    private float boostTimer;
    private float boostSpeed;
    private float normalSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        energy = maxEnergy;
        boostSpeed = moveSpeed * 2;
        normalSpeed = moveSpeed;

    }

    void Update()
    {
        counterText.text = energy.ToString();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //The following two 'if' statements move the player left and right by using the corresponding keys. This movement is done by adding force to the player, meaning they maintain momentum after the key is released.
        if (Input.GetKey(right))
        {
            rb.AddForce(this.transform.right * moveSpeed / 5);
        }

        if (Input.GetKey(left))
        {
            rb.AddForce(this.transform.right * (moveSpeed * -1) / 5);
        }

        //This allows the player to boost at any time, assuming they aren't already boosting, by pressing the corresponding key.
        if (Input.GetKey(boost) && isBoosting == false)
        {
            isBoosting = true;
            moveSpeed = boostSpeed;
        }

        //These two 'if' statements control the ending of the boost, and causes the player's energy to be consumed while boosting.
        if (isBoosting == true)
        {
            boostTimer += Time.deltaTime;
            energy -= energyUsage * Time.deltaTime;

            if (boostTimer >= 1)
            {
                isBoosting = false;
                boostTimer = 0;
                moveSpeed = normalSpeed;
            }
        }


        //The following allows the player's energy to be regenerated when not boosting.
        if (energy < maxEnergy && isBoosting == false)
        {
            energy += energyRegen * Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
