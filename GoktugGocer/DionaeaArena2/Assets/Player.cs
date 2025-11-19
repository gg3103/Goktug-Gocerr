using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [Header ("Movement details")]
    private float moveSpeed = 6f;
    private float jumpForce = 12;
    private float xInput;
    private bool facingRight = true;
    private bool canMove = true;


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

    public void EnableMovement(bool enable)
    {
        canMove = enable;
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
            TryToJump();

        if (Input.GetKeyDown(KeyCode.Z))
            TryToAttack();

    }

    private void TryToAttack()
    {
        anim.SetTrigger("attack");
    }




    private void TryToJump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void HandleMovement()
    {
        if(canMove == true)
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);

        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
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

