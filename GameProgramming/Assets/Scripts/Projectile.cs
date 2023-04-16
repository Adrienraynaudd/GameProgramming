
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damageOnTouch = 20;

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Projectile hit something");
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnTouch);
        }
            Destroy(gameObject);
    }
}
