using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    public PlayerMovement playerMovement;

    public float playerHealth;
    public float maxHealth;

    private float orangeHealth;
    private float currentOrange;

    public Image orangeOne;
    public Image orangeTwo;
    public Image orangeThree;
    public Image orangeFour;
    public Image orangeFive;

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

                if (playerHealth < 81)
                {
                    orangeFive.enabled = false;
                }
                if (playerHealth < 61)
                {
                    orangeFour.enabled = false;
                }
                if (playerHealth < 41)
                {
                    orangeThree.enabled = false;
                }
                if (playerHealth < 21)
                {
                    orangeTwo.enabled = false;
                }
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
