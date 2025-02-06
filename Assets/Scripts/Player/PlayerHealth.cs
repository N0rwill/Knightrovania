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

    public AudioSource hurtAudSource;
    public AudioClip hurtAud;
    public AudioSource deathAudSoure;
    public AudioClip deathAud;

    void Start()
    {
        playerDead = false;
        playerHealth = 100f;
        maxHealth = playerHealth;
        anim = GetComponent<Animator>();
    }

    public void Hurt()
    {
        if (playerDead != true)
        {
            if (playerHealth > 0)
            {
                hurtAudSource.PlayOneShot(hurtAud);
                playerHealth -= damage;
            }

            if (playerHealth <= 0)
            {
                playerDead = true;
                playerMovement.Dead();
                deathAudSoure.PlayOneShot(deathAud);
                anim.SetTrigger("Die");
                GameOverScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
