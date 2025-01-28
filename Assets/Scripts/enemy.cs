using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Animator anim;
    private bool isDead;
    private float deathDelay;

    void Awake()
    {
        anim = GetComponent<Animator>();
        deathDelay = 2f;
    }

    void Update()
    {
        //amage player
    }

    //damage player when it hits player

    //die when hit by player
    public void Hit()
    {
        //destroy enemy
        Debug.Log("hit enemy");
        //play death animation and set bool isDead to true
        isDead = true;
        anim.SetBool("isDead", isDead);
        //destroy after 2 seconds
        Destroy(this.gameObject, deathDelay);
    }

    //check if enemy hits player
    //void OnCollisionEnter(Collision col)
    //{
    //    if (CompareTag("Player"))
    //    {
    //        Debug.Log("col player");
    //        Hit();
    //    }
    //}
}
