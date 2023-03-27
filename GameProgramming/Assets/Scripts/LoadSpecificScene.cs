using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;
    public AudioClip sound;
    void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSysteme").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadScene());
        }
    }
    public IEnumerator LoadScene()
    {
        AudioManager.instance.PlayClipAt(sound, transform.position);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2.36f);
        SceneManager.LoadScene(sceneName);
    }
}
