using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour
{
     public int speed = 2;
     private Transform target;
    private Animator myAnimator;
    public int damageOnTouch = 70;
    private bool isAttacking = false;
    private int teleportation = -1;
    public int distance = 30;

      void Start() // this is called for get the animator component
    {
        myAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision) // this is called for check if the boss touch the player and if it is true then the player will take damage
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnTouch);
        }
    }
        private void OnTriggerStay2D(Collider2D collision){ // this is called for check if the player enter in boss detection area and if it is true then the boss will move to the player and use a random ability
        if(collision.transform.CompareTag("Player")){
            if(!isAttacking){
            StartCoroutine(randint(collision));
            teleportation = Random.Range(0, 5);
            if(teleportation == 1){
                target = collision.transform;
                Vector3 dir = target.position - transform.position;
                transform.position = new Vector3(target.position.x -1, target.position.y + 1, 0);
            }else if (teleportation == 2){
                target = collision.transform;
                Vector3 dir = target.position - transform.position;
                transform.position = new Vector3(target.position.x + distance, target.position.y, 0);
                }
            }
        }
        }
     private IEnumerator randint(Collider2D collision) // this is called for wait 0.3 seconds before the boss can use another ability
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.3f);
        isAttacking = false;
    }
}
