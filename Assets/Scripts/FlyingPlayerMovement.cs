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
        //This following line allows the player's energy value to be tracked as text on the UI.
        counterText.text = energy.ToString();

        //The following allows the player to jump by pressing the space bar, provided they are touching the ground and not currently flying.
        if (Input.GetButtonDown("Jump") && isGrounded && !isFlying)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //The following two 'if' statements allow the player to move left and right by using the corresponding keys.
        if (Input.GetKey(right))
        {
            this.transform.Translate(new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime);
        }

        if (Input.GetKey(left))
        {
            this.transform.Translate(new Vector3(moveSpeed * -1, 0f, 0f) * Time.deltaTime);
        }

        //The following two 'if' statements allow the player to move freely upwards and downwards while they are flying, by pressing the corresponding keys.
        if (Input.GetKey(up) && isFlying == true)
        {
            this.transform.Translate(new Vector3(0f, moveSpeed, 0f)
            * Time.deltaTime);
        }

        if (Input.GetKey(down) && isFlying == true)
        {
            this.transform.Translate(new Vector3(0f, moveSpeed * -1, 0f) * Time.deltaTime);
        }

        //The following allows the player to boost and increase their speed, but only while flying.
        if (Input.GetKey(boost) && isFlying == true && isBoosting == false)
        {
            isBoosting = true;
            moveSpeed = boostSpeed;
        }

        //The following manages the boosting function, causing energy to deplete faster while boosting and ending the boost after the time limit for it has been reached.
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

        //This following 'if' statement allows the player to start flying if press the jump button while already in the air.
        if (Input.GetButtonDown("Jump") && !isGrounded && canFly == true)
        {
            isFlying = true;
            rb.velocity = Vector2.zero;
        }

        //The follow cancels the player's flight and allows them to recharge energy.
        if (Input.GetKey(cancelFlight))
        {
            isFlying = false;
        }

        //The following two statements manage whether or not the player is able to initiate flight, based on whether to energy meter has been recently depleted or not.
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


        //The following two statements manage energy consumption for the player, depleting energy while flying and regenerating it while not flying.
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
