using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // this is called if the player enter in the weak spot and if is it true then the enemy will be destroyed
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
