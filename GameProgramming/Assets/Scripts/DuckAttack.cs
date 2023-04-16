using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAttack : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int damageOnTouch = 20;
    public int speed = 2;
    private Transform target;
    public Projectile projectile;
    public Transform firePoint;
    public Transform firePoint2;
    public Animator myAnimator;
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
            if (dir.x > 0){
                spriteRenderer.flipX = true;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
                 StartCoroutine(BackFire(collision));
            }
            if (dir.x < 0){
                spriteRenderer.flipX = false;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
                StartCoroutine(Fire(collision));
            }
        }
    }
    private IEnumerator Fire(Collider2D collision)
    {
        yield return new WaitForSeconds(1f);
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
     private IEnumerator BackFire(Collider2D collision)
    {
        yield return new WaitForSeconds(1f);
        Instantiate(projectile, firePoint2.position, firePoint2.rotation);
    }

}
