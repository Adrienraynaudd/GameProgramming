using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision) // this is called if the player enter in the coin and if is it true then the player will get the coin and the coin will be destroyed
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
