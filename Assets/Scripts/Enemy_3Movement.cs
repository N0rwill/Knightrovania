using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_3Movement : MonoBehaviour
{
    public EnemyHurt enemyHurt;

    public Transform player;

    public Camera mainCamera;
    private float despawnDistanceX = 15f;
    private float despawnDistanceY = 15f;

    public float speed;
    private float playerPos;
    private float enemyPos;

    private bool isMoving;
    private Animator anim;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D hitBox;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerPos = player.transform.position.x;
        enemyPos = transform.position.x;

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        AnimationController();
        Despawn();
    }

    void FixedUpdate()
    {
        if (!enemyHurt.isDead)
        {
            //move right
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            
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
            player = gameObject.GetComponent<Transform>();   
            float distanceX = Mathf.Abs(transform.position.x - player.position.x);
            float distanceY = Mathf.Abs(transform.position.y - player.position.y);

            if (distanceX >= despawnDistanceX || distanceY >= despawnDistanceY)
            {
                Destroy(gameObject);
            }
        }
    }
}
