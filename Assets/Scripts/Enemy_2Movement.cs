using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2Movement : MonoBehaviour
{
    public EnemyHurt enemyHurt;

    public Camera mainCamera;
    public float despawnDistanceX = 15f;
    public float despawnDistanceY = 15f;
    public Transform player;
    private bool isMoving;
    private Animator anim;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] private BoxCollider2D hitBox;

    void Awake()
    {
        anim = GetComponent<Animator>();

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            Debug.Log("cam set");
        }
    }

    void Update()
    {
        AnimationController();
        Despawn();
    }

    void FixedUpdate()
    {
        //if enemy not dead
        if (!enemyHurt.isDead)
        {
            rb.velocity = new Vector2(-1, rb.velocity.y) * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            hitBox.enabled = false;
        }
    }

    private void AnimationController()
    {
        //check if moving in animator
        isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);
    }

    void Despawn()
    {
        if (mainCamera != null)
        {
            float distanceX = Mathf.Abs(transform.position.x - mainCamera.transform.position.x);
            float distanceY = Mathf.Abs(transform.position.y - mainCamera.transform.position.y);

            if (distanceX >= despawnDistanceX || distanceY >= despawnDistanceY)
            {
                Destroy(gameObject);
            }
        }
    }
}
