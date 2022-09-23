using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    Vector3 velocity;
    public LayerMask groundMask;
    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public float turnSmoothTime = 0.1f;

    public float speed = 12;

    public float gravity = -9.81f * 2;
    public float jumpHeight = 1f;

    public int maxHealth = 100;
    public int currentHealth;

    private bool isGrounded;

    float turnSmoothVelocity;

    public HealthBar healthbar;
    public Death deathScript;
    public Transform Player;

    

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Don't let health go over max amount.
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            healthbar.SetHealth(currentHealth);
        }

        // Player Movement code
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    void Start()
    {

        speed = 6f;

        currentHealth = maxHealth;

        healthbar.SetMaxHealth(maxHealth);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        deathScript.TurnOnScreen();
    }


}
