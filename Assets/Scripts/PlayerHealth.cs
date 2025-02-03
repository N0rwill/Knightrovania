using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth;
    public float damage = 10f;

    void Start()
    {
        playerHealth = 100f;
        maxHealth = playerHealth;
    }

    void Update()
    {
        
    }

    public void Hurt()
    {
        playerHealth -= damage;
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
            Hurt();
        }
    }
}
