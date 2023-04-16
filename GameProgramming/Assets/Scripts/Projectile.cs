
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public int damageOnTouch = 20;
   
   void Start(){
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
   }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Projectile hit something");
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnTouch);
        }
        if (collision)
        if(collision.gameObject.layer != 6){
             Destroy(gameObject);
        }
    }
}
