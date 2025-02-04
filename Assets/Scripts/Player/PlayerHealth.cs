using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    public PlayerMovement playerMovement;

    public float playerHealth;
    public float maxHealth;
    public float damage = 10f;
    public bool playerDead;
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
            if (playerHealth > 0)
            {
                playerHealth -= damage;
            }

            if (playerHealth <= 0)
            {
                playerDead = true;
                playerMovement.Dead();
                anim.SetTrigger("Die");
                GameOverScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
