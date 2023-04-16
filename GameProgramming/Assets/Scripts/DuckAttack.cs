using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAttack : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int damageOnTouch = 20;
    public int speed = 2;
    private Transform target;
    public GameObject projectile;
    public Transform firePoint;
    public Transform firePoint2;
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
            target = collision.transform;
            Vector3 dir = target.position - transform.position;
            dir.y = 0;
            if (dir.x > 0){ // if the player is on the right side of the duck then the duck will move to the right side and the projectile will be flipped
                spriteRenderer.flipX = true; // flip the sprite
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
                if (!isAttacking){
                    StartCoroutine(Fire(collision));
                    GameObject proj = Instantiate(projectile, firePoint2.position, firePoint2.rotation); // instantiate the projectile
                    proj.GetComponent<SpriteRenderer>().flipX = true;
                    proj.GetComponent<SpriteRenderer>().flipY = false;
                }
            }
            if (dir.x < 0){
                spriteRenderer.flipX = false;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
                if (!isAttacking)
                {
                    StartCoroutine(Fire(collision));
                     GameObject proj = Instantiate(projectile, firePoint.position, firePoint.rotation);
                    proj.GetComponent<SpriteRenderer>().flipX = true;
                    proj.GetComponent<SpriteRenderer>().flipY = true;
                }

            }
        }
    }
    private IEnumerator Fire(Collider2D collision)
    {
        isAttacking = true;
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        
    }

}
