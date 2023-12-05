using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 7f;
    public float maxEnergy = 100f;
    public float energyUsage = 10f;
    public float energyRegen = 10f;
    public string left;
    public string right;
    public string up;
    public string down;
    public string cancelFlight;
    public string boost;
    public Text counterText;

    private bool isGrounded;
    private bool isFlying;
    private bool canFly;
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

        if (Input.GetButtonDown("Jump") && isGrounded && !isFlying)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKey(right))
        {
            this.transform.Translate(new Vector3(moveSpeed, 0f, 0f)
            * Time.deltaTime);
        }

        if (Input.GetKey(left))
        {
            this.transform.Translate(new Vector3(moveSpeed * -1, 0f, 0f) * Time.deltaTime);
        }

        if (Input.GetKey(up) && isFlying == true)
        {
            this.transform.Translate(new Vector3(0f, moveSpeed, 0f)
            * Time.deltaTime);
        }

        if (Input.GetKey(down) && isFlying == true)
        {
            this.transform.Translate(new Vector3(0f, moveSpeed * -1, 0f) * Time.deltaTime);
        }

        if (Input.GetKey(boost) && isFlying == true && isBoosting == false)
        {
            isBoosting = true;
            moveSpeed = boostSpeed;
        }

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

        if (Input.GetButtonDown("Jump") && !isGrounded && canFly == true)
        {
            isFlying = true;
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKey(cancelFlight))
        {
            isFlying = false;
        }

        if (energy <=0)
        {
            canFly = false;
            isFlying = false;
        }
        else
        {
            if (energy >= 100)
            {
                canFly = true;
            }
        }


        if (isFlying == true)
        {
            rb.gravityScale = 0.0f;
            energy -= energyUsage * Time.deltaTime;
        }

        if (isFlying == false)
        {
            rb.gravityScale = 1.0f;
            if (energy < maxEnergy)
            {
                energy += energyRegen * Time.deltaTime;
            }
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
