using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject pelletPrefab;
    public Transform shootPoint;
    public float shootForce = 10f;
    public float shootRate = 0.5f;

    public Animator animator;

    private float nextShootTime = 0f;
    private Vector2 lastMovementDirection = Vector2.up; // Default to up (can be any initial direction)

    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the movement vector to avoid faster diagonal movement
        movement.Normalize();

        // Update last movement direction (if there's any movement)
        if (movement.magnitude > 0.1f)
        {
            lastMovementDirection = movement;
        }

        // Check for player input to shoot
        if (Input.GetButton("Fire1") && Time.time >= nextShootTime)
        {
            ShootPellet();
            animator.SetBool("Fired", true);
            nextShootTime = Time.time + 1f / shootRate; // Update next shoot time based on shoot rate
        }
        if (Input.GetButtonUp("Fire1") && Time.time <= nextShootTime)
        {
            animator.SetBool("Fired", false);

        }
    }

    void ShootPellet()
    {
        // Instantiate a pellet prefab at the shoot point
        GameObject pellet = Instantiate(pelletPrefab, shootPoint.position, Quaternion.identity);

        // Apply force to the pellet based on the last movement direction
        Rigidbody2D pelletRb = pellet.GetComponent<Rigidbody2D>();
        pelletRb.AddForce(lastMovementDirection * shootForce, ForceMode2D.Impulse);
    }

    // Detect collisions with pellets
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pellet2"))
        {
            // Assuming each pellet does 20 damage
            int damage = 20;

            // Get the PlayerHealth component of the player that was hit
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();

            // Apply damage to the player
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Destroy the pellet on collision
            Destroy(other.gameObject);
            // Debug.Log(playerHealth.GetCurrentHealth());
        }
    }
}

