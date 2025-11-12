using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [Header ("Movement details")]
    private float moveSpeed = 6f;
    private float jumpForce = 12;
    private float xInput;
    private bool facingRight = true;

    [Header("Collusion details")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    // Update is called once per frame
    private void Update()
    {

        HandleCollision();
        HandleInput();

        HandleMovement();

        HandleAnimatons();
        HandleFlip();
    }



    private void HandleAnimatons()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        anim.SetBool("isGrounded", isGrounded);
        
    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
            Jump();

    }


    private void HandleMovement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);
    }

    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);

    }

    private void HandleFlip()
    {
        if(rb.linearVelocity.x > 0 && facingRight == false)
            Flip();
        else if(rb.linearVelocity.x < 0 && facingRight == true)
            Flip();

    }

    private void Flip()
    {

        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
    }


}

