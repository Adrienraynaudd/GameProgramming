using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageOnTouch = 40;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnTouch);
        }
    }
}
