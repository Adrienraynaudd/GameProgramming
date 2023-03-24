using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;
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
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
