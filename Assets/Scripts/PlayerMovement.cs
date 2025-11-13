using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Flip player sprite
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
