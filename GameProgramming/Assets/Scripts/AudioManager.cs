
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public static AudioManager instance;
    private int index = 0;

    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }
    public void PlayNextSong()
    {
        index++;
        if (index >= playlist.Length)
        {
            index = 0;
        }
        audioSource.clip = playlist[index];
        audioSource.Play();
    }
}
