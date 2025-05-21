using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator animator;

    bool isGrounded = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       // Deteksi tanah pakai OverlapCircle
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    animator.SetBool("isJumping", !isGrounded);

    float xInput = 0f;

    if (Input.GetKey(KeyCode.RightArrow))
    {
        xInput = 1f;
        sprite.flipX = false;
    }
    else if (Input.GetKey(KeyCode.LeftArrow))
    {
        xInput = -1f;
        sprite.flipX = true;
    }

    body.velocity = new Vector2(xInput * speed, body.velocity.y);

    animator.SetFloat("xVelocity", Mathf.Abs(body.velocity.x));

    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }
    void OnDrawGizmosSelected()
{
    if (groundCheck != null)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}}
}
