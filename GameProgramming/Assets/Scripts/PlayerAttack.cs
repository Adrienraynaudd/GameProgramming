using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Update is called once per frame
    public Animator animator;
    public Transform attackPoint;
     private Transform target;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 50;
    void Update()
    {

    }

    void OnAttack ()
    {
        Attack();   
    }

    void Attack()
    {
        animator.SetTrigger("Attacks");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // this is called for check if the player is attacking and if it is true then the enemy will take damage

        foreach (Collider2D enemy in hitEnemies)
        {
            target = enemy.transform;
            Vector3 dir = target.position - transform.position;
            if (dir.magnitude < 2)
            {
                enemy.GetComponent<enemyLife>().TakeDamage(attackDamage);
            }
        }
    }
    void OnDrawGizmosSelected() // this is draw the attack range of the player
        {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
}
