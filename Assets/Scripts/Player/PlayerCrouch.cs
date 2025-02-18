using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public PlayerHealth playerHealth;
    
    private float crouchHeight;
    private float normalHeight;
    public bool isCrouching;
    
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider2D bc;

    void Start()
    {
        crouchHeight = 0.9f;
        normalHeight = 3f;
    }

    void Update()
    {
        Crouch();  
    }
    public void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !playerHealth.playerDead)
        {
            //Crouch
            bc.size = new Vector2(bc.size.x, crouchHeight);
            isCrouching = true;
            //crouch anim
            anim.Play("Crouch");
            //is crouching anim bool true
            anim.SetBool("isCrouching", isCrouching);
        }
        else
        {
            anim.SetBool("isCrouching", isCrouching);
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow) && !playerHealth.playerDead)
        {
            //stop crouching
            isCrouching = false;
            bc.size = new Vector2(bc.size.x, normalHeight);
            //iscrouching anim bool false
            anim.SetBool("isCrouching", !isCrouching);
        }
    }
}
