using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerHealth phealth;

    [SerializeField] private Animator anim;
    private bool isDead = false;

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    void Update()
    {
        
    }

    //die when hit by player
    public void Hit()
    {
        if (isDead) return;
        Debug.Log("PLayer hit " + gameObject.name);
        isDead = true;
        anim.SetTrigger("Die");
        float deathAnimTime = anim.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, deathAnimTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if hit game object with tag enemy run enemy hit script
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered collision with " + col.gameObject.name);
            Hit();
            phealth.Hurt();
        }
    }
}
