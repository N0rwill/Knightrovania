using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {

    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    // [SerializeField] private Rigidbody2D rb;
    // private float dirx;
    // private float moveSpeed = 2f;

    // void Start()
    // {
        
    // }

    // void FixedUpdate()
    // {
    //     rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);
    // }
}
