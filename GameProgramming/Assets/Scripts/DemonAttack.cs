using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : MonoBehaviour
{


    public int speed = 2;
    private Transform target;
    private Animator myAnimator;
    public int damageOnTouch = 20;
    private int saut = -1;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
     private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            target = collision.transform;
            Vector3 dir = target.position - transform.position;
            dir.y=0;
             transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
             if(dir.magnitude<5)
             {
                    StartCoroutine(Fire(collision));
             }else
             {
                StartCoroutine(randint(collision));
                if (saut == 1)
                {
                    StartCoroutine(Jump(collision));
                }
             }
        }
    }
    private IEnumerator Fire(Collider2D collision)
    {
        myAnimator.SetTrigger("Fire");
        yield return new WaitForSeconds(1.5f);
        myAnimator.SetTrigger("notFire");
        
    }
    private IEnumerator Jump(Collider2D collision)
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
          saut = Random.Range(0, 5);
    }
}
