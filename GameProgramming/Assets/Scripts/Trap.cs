using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            PlayerHealth.instance.isinvincible = false;
            PlayerHealth.instance.TakeDamage(10000);
        }
    }

}
