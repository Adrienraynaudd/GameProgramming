using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healPoints = 20;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.HealPlayer(healPoints);
            Destroy(gameObject);
        }
    }
}
