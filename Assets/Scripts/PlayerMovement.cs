using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    public float raycastDistance = 0.01f;
    private bool isJumping = false;
    private Rigidbody rb;

    private float jumpForce = 16f;

    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float verticalMove = 0.5f;

    private Animator animator;
    private AudioSource[] audioSources;
    private AudioSource jumpSound;
    private AudioSource walkSound;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2)
        {
            jumpSound = audioSources[0];
            walkSound = audioSources[1];
        }
    }
    private void Update() {

        HandleMovementInput();

       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            isGrounded = CheckIfGrounded();
            JumpMovement();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

public void JumpMovement()
    {
        if (isGrounded == false) { return; }
        if (rb == null) { return; }
        if (isJumping == false) { return; }
        isGrounded = false;
        Vector3 v3 = rb.velocity;
        v3.y = 0;
        rb.velocity = v3;
        rb.AddForce(0, jumpForce * verticalMove, 0, ForceMode.VelocityChange);
        // Play jump sound
        if (jumpSound != null)
        {
            jumpSound.Play();
        }
    }
bool CheckIfGrounded()
    {
        // Create a ray from the center of the game object straight down
        Ray ray = new Ray(transform.position, Vector3.down);

        // Check if the ray hits something within the specified distance
        return Physics.Raycast(ray, raycastDistance);
    }


void HandleMovementInput()
    {

        if (rb == null) { return; }
        // Get input from WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // If there is any movement input, rotate towards the movement direction
        if (movement.magnitude >= 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
       
            // Set the "Walk" parameter in the Animator to trigger the walking animation
            animator.SetBool("Walk", true);
            // Play walk sound
            if (walkSound != null && !walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else
        {
            // If there is no movement input, stop the walking animation
            animator.SetBool("Walk", false);
            if (walkSound != null)
            {
                walkSound.Stop();
            }
        }

        // Move the character
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

}

