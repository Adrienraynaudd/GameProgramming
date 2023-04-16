using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoin(1);
            CurrentSceneManager.instance.CoinsPickedUp++;
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Destroy(gameObject);
        }
    }
}
