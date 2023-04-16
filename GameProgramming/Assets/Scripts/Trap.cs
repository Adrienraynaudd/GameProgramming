using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // this is called if the player enter in the trap and if is it true then the player will die
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(10000);
        }
    }

}
