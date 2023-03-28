
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int index = 0;
    public AudioMixerGroup soundEffectMixer;
     public static AudioManager instance;

   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of AudioManager found!");
           return;
       }
       instance = this;
   }
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
    public AudioSource PlayClipAt(AudioClip clip , Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position
        AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
        aSource.clip = clip; // define the clip
         //aSource.outputAudioMixerGroup = soundEffectMixer; // set the output to the sound effect mix
        aSource.Play(); // start the sound
        Destroy(tempGO, clip.length); // destroy object after clip duration
        return aSource; // return the AudioSource reference
    }
}
