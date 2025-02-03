using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    public bool isDead;

    public void Start()
    {
        isDead = false;
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    //die when hit by player
    public void Hit()
    {
        //if already dead  don't run
        if (isDead) return;
        
        Debug.Log("PLayer hit " + gameObject.name);
        isDead = true;
        anim.SetTrigger("Die");

        float deathAnimTime = anim.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, deathAnimTime);
    }
}
