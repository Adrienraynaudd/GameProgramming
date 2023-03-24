
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

    public static PlayerHealth instance;
    

   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of PlayerHealth found!");
           return;
       }
       instance = this;
   }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.H)){
            TakeDamage(100);
        }
    }
    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        if (!isinvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if(currentHealth <= 0)
            {
                Die();
                return;
            }
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
        public void Die()
        {
            Debug.Log("Player died!");
            PlayerMovement.instance.enabled = false;
            PlayerMovement.instance.animator.SetTrigger("Die");
            PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Static;
            PlayerMovement.instance.playerCollider.enabled = false;
            GameOverManager.instance.OnPlayerDeath();
        }
        public void respawnPlayer()
        {
            PlayerMovement.instance.enabled = true;
            PlayerMovement.instance.animator.SetTrigger("Respawn");
            PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
            PlayerMovement.instance.playerCollider.enabled = true;
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
}