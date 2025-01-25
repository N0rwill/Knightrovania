using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Update()
    {
        if(Input.GetKeyDown("z"))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play attack animation
        anim.Play("Attack3");
        //Detect enemies in range of attack
        //Damage the enemies
    }
}
