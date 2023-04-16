using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : MonoBehaviour
{


    public int speed = 2;
    private Transform target;
    private Animator myAnimator;
    public int damageOnTouch = 20;
    private int jump = -1;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnTouch);
        }
    }
     private void OnTriggerStay2D(Collider2D collision) // this is called for check if the player enter in the demon detection area and if it is true then the demon will move to the player
    {
        if (collision.transform.CompareTag("Player"))
        {
            target = collision.transform;
            Vector3 dir = target.position - transform.position;
            dir.y=0;
             transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
             if(dir.magnitude<5) // if the player is close to the demon then the demon will attack with fireball the player
             {
                    StartCoroutine(Fire(collision));
             }else
             {
                StartCoroutine(randint(collision)); // if the player is far from the demon then the demon will jump to the player
                if (jump == 1)
                {
                    StartCoroutine(Jump(collision));
                }
             }
        }
    }
    private IEnumerator Fire(Collider2D collision) // this is called for check if the demon is attacking with fireball
    {
        myAnimator.SetTrigger("Fire");
        yield return new WaitForSeconds(1.5f);
        myAnimator.SetTrigger("notFire");
        
    }
    private IEnumerator Jump(Collider2D collision) // this is called for check if the demon is jumping to the player
    {
         target = collision.transform;
        Vector3 dir = target.position - transform.position;
        transform.Translate(Vector3.up * 1000 * Time.deltaTime, Space.World);
         myAnimator.SetTrigger("JumpAttack");
        yield return new WaitForSeconds(5f);
        transform.position = new Vector3(target.position.x +3, target.position.y + 1, 0);
        myAnimator.SetTrigger("notJump");
    }
    private IEnumerator randint(Collider2D collision)
    {
        yield return new WaitForSeconds(5f);
          jump = Random.Range(0, 5);
    }
}
