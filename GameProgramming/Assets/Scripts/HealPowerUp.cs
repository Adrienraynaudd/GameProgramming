using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healPoints = 20;
    public AudioClip sound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            PlayerHealth.instance.HealPlayer(healPoints);
            Destroy(gameObject);
        }
    }
}
