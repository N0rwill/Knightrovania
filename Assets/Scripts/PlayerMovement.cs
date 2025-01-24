using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed;
    private float jumpingPower;
    private bool isFacingRight = true;
    public bool isMoving;
    private bool isGrounded;
    private Animator anim;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        speed = 4f;
        jumpingPower = 14f;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Get player movement
        horizontal = Input.GetAxis("Horizontal");

        //jump if grounded
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.Play("Jump");
        }

        anim.SetFloat("AirSpeedY", rb.velocity.y);

        Flip();
        AnimationController();
        GroundChecker();
    }

    private void FixedUpdate()
    {
        //move player
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void GroundChecker()
    {
        //ground check
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", isGrounded);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGrounded", !isGrounded);
        }
    }

     private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    private void Flip()
    {
        //flip player sprite
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void AnimationController()
    {
        isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);
    }

}
