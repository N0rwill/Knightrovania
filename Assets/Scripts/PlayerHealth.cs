using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth;
    public float damage = 10f;
    private bool playerDead;
    private Animator anim;

    void Start()
    {
        playerDead = false;
        playerHealth = 100f;
        maxHealth = playerHealth;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Hurt()
    {
        if (playerDead != true)
        {
            playerHealth -= damage;

            if (playerHealth <= 0)
            {
                playerDead = true;
                anim.SetTrigger("Die");
            }
        }
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
