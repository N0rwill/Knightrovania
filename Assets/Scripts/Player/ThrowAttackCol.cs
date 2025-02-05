using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAttackCol : MonoBehaviour
{
    public Camera mainCamera;
    public float despawnDistanceX = 15f;
    public float despawnDistanceY = 10f;

    void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }
    void Update()
    {
        Despawn();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            EnemyHurt enemy = col.GetComponent<EnemyHurt>();
            if (enemy != null)
            {
                enemy.Hit();
            }
        }
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
