using UnityEngine;
using System.Collections;
public class DeathZone : MonoBehaviour

{

    private Animator fadeSystem;
    private void Awake()
    {
       fadeSystem = GameObject.FindGameObjectWithTag("FadeSysteme").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision) // this is called if the player enter in the death zone and if is it true then the player will respawn
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(FadeIn(collision));
        }
    }
    private IEnumerator FadeIn(Collider2D collision) // this is called to fade in the screen and then the player will respawn
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2.36f);
        collision.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
    }
}
 