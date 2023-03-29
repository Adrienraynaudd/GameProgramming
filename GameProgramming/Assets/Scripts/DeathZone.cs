using UnityEngine;
using System.Collections;
public class DeathZone : MonoBehaviour

{

    private Animator fadeSystem;
    private void Awake()
    {
       fadeSystem = GameObject.FindGameObjectWithTag("FadeSysteme").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(FadeIn(collision));
        }
    }
    private IEnumerator FadeIn(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
         collision.transform.position = CurrentSceneManager.instance.PlayerRespawnPosition;
    }
}
 