using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantAttack : MonoBehaviour
{
    public int damageOnTouch = 20;
    public int speed = 2;
    public GameObject projectile;
    public Transform firePoint;
    public Animator myAnimator;

     private bool isAttacking = false;

       private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnTouch);
        }
    }
     private void OnTriggerStay2D(Collider2D collision)
    {
        myAnimator.SetTrigger("enter");
        if (collision.transform.CompareTag("Player"))
        {
             if (!isAttacking){
                    StartCoroutine(Fire(collision));
                    GameObject proj = Instantiate(projectile, firePoint.position, firePoint.rotation);
            }
         }
    }
    void OnTriggerExit2D(Collider2D other){
        myAnimator.SetTrigger("exit");
    }
     private IEnumerator Fire(Collider2D collision)
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
        
    }
}
