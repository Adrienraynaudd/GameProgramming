using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public int damageOnTouch = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        //PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            //playerHealth.TakeDamage(damageOnTouch);
    }
        private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            target = collision.transform;
            Vector3 dir = target.position - transform.position;
             transform.Translate(dir.normalized * 2 * Time.deltaTime, Space.World);
        }
    }
}
