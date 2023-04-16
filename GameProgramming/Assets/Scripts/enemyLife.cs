using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public AudioClip killSound;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void  TakeDamage(int damage) // this is called for check if the enemy is taking damage
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            return;
        }
    }
    void Die() // this is called for check if the enemy is dead
    {
        AudioManager.instance.PlayClipAt(killSound, transform.position);
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
