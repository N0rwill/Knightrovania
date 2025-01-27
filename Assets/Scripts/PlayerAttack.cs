using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public enemy enemy;

    [SerializeField] private Animator anim;
    [SerializeField] private Transform attackPos;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask enemyLayer;

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
        if (Physics2D.BoxCast(attackPos.transform.position, boxSize, 0, transform.right, castDistance,  enemyLayer))
        {
            //damage enemy
            enemy.Hit();
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackPos.transform.position+transform.right * castDistance, boxSize);
    }
}
