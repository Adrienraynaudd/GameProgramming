using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushAttack : MonoBehaviour
{
     public int speed = 1;
    private Transform target;
    private Animator myAnimator;
    public int damageOnTouch = 50;
    // Start is called before the first frame update
    void Start(){
        myAnimator = GetComponent<Animator>();
    }
             private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnTouch);
        }
    }
    private void OnColliderEnter2D(Collider2D collision){
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
        private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            myAnimator.SetTrigger("enter");
            target = collision.transform;
            Vector3 dir = target.position - transform.position;
            dir.y = 0;
             transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
