using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healPoints = 20;
    public AudioClip sound;
    void OnTriggerEnter2D(Collider2D collision) // this is called if the player enter in the heal power up and if is it true then the player will heal and the power up will be destroyed
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            PlayerHealth.instance.HealPlayer(healPoints);
            Destroy(gameObject);
        }
    }
}
