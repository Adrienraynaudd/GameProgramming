
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public float invincibilityTime = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public SpriteRenderer graphics;
    public bool isinvincible = false;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TakeDamage(int damage)
    {
        if (!isinvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isinvincible = true;
            StartCoroutine(invincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }
    public IEnumerator invincibilityFlash()
{
  while (isinvincible)
  {
    graphics.color = new Color(1f, 1f, 1f, 0f);
    yield return new WaitForSeconds(invincibilityFlashDelay);
    graphics.color = new Color(1f, 1f, 1f, 1f);
    yield return new WaitForSeconds(invincibilityFlashDelay);
  }
}
    public IEnumerator HandleInvincibilityDelay()
        {
        yield return new WaitForSeconds(invincibilityTime);
        isinvincible = false;
        }
}

