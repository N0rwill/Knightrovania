using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
        GetComponent<Collider>().enabled = false;
        float deathAnimTime = anim.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, deathAnimTime);
    }
}
