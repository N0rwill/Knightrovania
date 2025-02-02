using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth;
    public float damage = 20f;

    void Start()
    {
        maxHealth = playerHealth;
    }

    void Update()
    {
        
    }

    public void Hurt()
    {
        playerHealth -= damage;
    }
}
