using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerCrouch playerCrouch;
    public PlayerHealth playerHealth;

    private float horizontal;
    private float speed;
    private float jumpingPower;
    private bool isFacingRight = true;
    private bool isMoving;
    private bool isGrounded;
    private bool isStunned;
    private Animator anim;

    public Transform enemyDirection;

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
        if(Input.GetButtonDown("Jump") && isGrounded && !isStunned && !playerCrouch.isCrouching && !playerHealth.playerDead)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.Play("Jump");
        }

        Flip();
        AnimationController();
        GroundChecker();
    }

    private void FixedUpdate()
    {
        //move player if not crouching
        if(!isStunned && !playerCrouch.isCrouching && !playerHealth.playerDead)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        if (playerCrouch.isCrouching)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
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

    //draws groundcheck gizmo
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    private void Flip()
    {
        //flip player sprite
        if((isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) && !playerHealth.playerDead)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void AnimationController()
    {
        //set air speed in animator
        anim.SetFloat("AirSpeedY", rb.velocity.y);
        //check if moving in animator
        isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            EnemyHurt enemy = col.GetComponent<EnemyHurt>();
            if (enemy != null)
            {
                enemy.Hit();
                enemyDirection = col.GetComponent<Transform>();
                if (enemyDirection.transform.position.x > transform.position.x)
                {
                    knockbackLeft();
                }
                if (enemyDirection.transform.position.x < transform.position.x)
                {
                    knockbackRight();
                }
            }
            playerHealth.Hurt();
        }
    }

    public void knockbackLeft()
    {
        if (!playerHealth.playerDead)
        {
        StartCoroutine(StunPlayerLeft(0.44f));
        anim.SetTrigger("Hurt");
        }
    }

    IEnumerator StunPlayerLeft(float duration)
    {
        isStunned = true;
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(-0.5f, 2f) * speed;
        yield return new WaitForSeconds(duration);
        isStunned = false;
    }

    public void knockbackRight()
    {
        if (!playerHealth.playerDead)
        {
            StartCoroutine(StunPlayerRight(0.44f));
            anim.SetTrigger("Hurt");
        }
    }

    IEnumerator StunPlayerRight(float duration)
    {
        isStunned = true;
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(0.5f, 2f) * speed;
        yield return new WaitForSeconds(duration);
        isStunned = false;
    }

    public void Dead()
    {
        rb.velocity = Vector2.zero;
    }
}
