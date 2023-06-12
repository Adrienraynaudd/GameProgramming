
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public HealthBar healthBar;
    public HealthBar healthBar2;
    public float invincibilityTime = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public SpriteRenderer graphics;
    public bool isinvincible = false;
    public AudioClip hitSound;

    public PlayerHealth player;
    public PlayerMovement playerMov;

    public static PlayerHealth instance;
    

   private void Awake()
   {
       instance = this;
   }
   void Start(){
    player.currentHealth = player.maxHealth;
   }

    // Update is called once per frame
    public void HealPlayer(int healAmount) // this is called for check if the player is healing
    {
        currentHealth += healAmount;
        player.currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (player.currentHealth > player.maxHealth)
        {
            player.currentHealth = player.maxHealth;
        }
        healthBar.SetHealth(currentHealth);
        healthBar2.SetHealth(player.currentHealth);
    }
    public void TakeDamage(int damage) // this is called for check if the player is taking damage
    {
        if (!isinvincible) // this is called for check if the player is  not invincible
        {
            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if(currentHealth <= 0)
            {
                Die(); // this is called for check if the player is dead
                return;
            }
            isinvincible = true;
            StartCoroutine(invincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }
    public IEnumerator invincibilityFlash() // this is called for flash the sprite of the player when he is invincible
{
  while (isinvincible)
  {
    graphics.color = new Color(1f, 1f, 1f, 0f);
    yield return new WaitForSeconds(invincibilityFlashDelay);
    graphics.color = new Color(1f, 1f, 1f, 1f);
    yield return new WaitForSeconds(invincibilityFlashDelay);
  }
}
    public IEnumerator HandleInvincibilityDelay() // this is called for duration of the invincibility of the player
        {
        yield return new WaitForSeconds(invincibilityTime);
        isinvincible = false;
        }
        public void Die() // this is called for check if the player is dead
        {
            Debug.Log("Player died!");
            PlayerMovement.instance.enabled = false;
            PlayerMovement.instance.animator.SetTrigger("Die");
            PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Static;
            PlayerMovement.instance.playerCollider.enabled = false;
             PlayerMovement.instance.animator2.SetTrigger("Die");
             playerMov.enabled = false;
            playerMov.rb.bodyType = RigidbodyType2D.Static;
            playerMov.playerCollider.enabled = false;
            GameOverManager.instance.OnPlayerDeath();
        }
        public void respawnPlayer() // this is called for check if the player is respawning
        {
            PlayerMovement.instance.enabled = true;
            PlayerMovement.instance.animator.SetTrigger("Respawn");
            PlayerMovement.instance.animator2.SetTrigger("Respawn");
            PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
            PlayerMovement.instance.playerCollider.enabled = true;
            playerMov.enabled = true;
            playerMov.rb.bodyType = RigidbodyType2D.Dynamic;
            playerMov.playerCollider.enabled = true;
            currentHealth = maxHealth;
            player.currentHealth = player.maxHealth;
            player.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
             transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
            healthBar.SetHealth(maxHealth);
            healthBar2.SetHealth(maxHealth);
        }
}