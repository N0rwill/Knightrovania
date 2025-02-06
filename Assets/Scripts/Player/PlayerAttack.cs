using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;

    [SerializeField] private Animator anim;
    [SerializeField] private Transform attackPos;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private Transform throwPoint;
    public float throwForce;
    public float throwAngle;
    private bool canThrow = true;
    public float throwCooldown = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !playerHealth.playerDead)
        {
            Attack();
        }

        //press z run attack funtion
        if (Input.GetKeyDown(KeyCode.UpArrow) && !playerHealth.playerDead && canThrow)
        {
            AttackThrow();
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
            EnemyHurt enemy = hit.GetComponent<EnemyHurt>();
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

    private void AttackThrow()
    {
        if (weaponPrefab == null || throwPoint == null) return;

        anim.Play("Throw");

        canThrow = false;
        StartCoroutine(ResetThrowCooldown());

        GameObject thrownWeapon = Instantiate(weaponPrefab, throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = thrownWeapon.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            float direction = transform.localScale.x > 0 ? 1f : -1f;
            Vector2 throwDirection = new Vector2(direction * Mathf.Cos(throwAngle * Mathf.Deg2Rad), Mathf.Sin(throwAngle * Mathf.Deg2Rad));
            rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
            thrownWeapon.transform.Rotate(0, 0, 90);
        }
    }

    private IEnumerator ResetThrowCooldown()
    {
        yield return new WaitForSeconds(throwCooldown);
        canThrow = true;
    }
}
