using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float moveSpeed = 3f; 
    public int damage = 5;


    void Update()
    {
        transform.position = new Vector3(
            transform.position.x + (moveSpeed * Time.deltaTime),
            transform.position.y,
            transform.position.z
            );
    }

    private void OntriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}