using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundPlayerMovement : MonoBehaviour
{
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

        if (Input.GetKey(right))
        {
            rb.AddForce(this.transform.right * moveSpeed / 5);
        }

        if (Input.GetKey(left))
        {
            rb.AddForce(this.transform.right * (moveSpeed * -1) / 5);
        }

        if (Input.GetKey(boost) && isBoosting == false)
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
