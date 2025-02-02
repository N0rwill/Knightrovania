using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform attackPos;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask enemyLayer;

    void Update()


    {
        //press z run attack funtion
        if(Input.GetKeyDown("z"))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play attack animation
        anim.Play("Attack3");

        //Detect all enemies in the attack range
        Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(attackPos.position + (Vector3)transform.right * castDistance, boxSize, 0, enemyLayer);
        
        //hit all enemies and run hit script
        foreach (Collider2D hit in enemiesHit)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Hit();
            }
        }
        
    }
    
    //draw attack gizmo
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackPos.transform.position+transform.right * castDistance, boxSize);
    }
}
