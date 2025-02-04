using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2Movement : MonoBehaviour
{
    public EnemyHurt enemyHurt;

    public Camera mainCamera;
    public Transform player;
    public float verticalSpeed = 3f;
    public float horizontalSpeed = 2f;
    public float verticalRange = 0.44f;

    private Vector3 startPosition;
    private float verticalOffset;
    private float despawnDistanceX = 15f;
    private float despawnDistanceY = 15f;
    private bool isMoving;
    private Animator anim;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D hitBox;

    void Awake()
    {
        startPosition = transform.position;
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
            // Move the enemy to the left
            transform.position += Vector3.left * horizontalSpeed * Time.deltaTime;

            // Calculate the vertical oscillation (up and down)
            verticalOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalRange;

            // Update the vertical position
            transform.position = new Vector3(transform.position.x, startPosition.y + verticalOffset, transform.position.z);
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
