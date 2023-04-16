
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist; // this is the playlist of the songs
    public AudioSource audioSource; // this is the audio source of the songs
    private int index = 0;
    public AudioMixerGroup soundEffectMixer;
     public static AudioManager instance;

   private void Awake() // this is called for create the instance of the class and make sure that there is only one instance of the class in the scene
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of AudioManager found!");
           return;
       }
       instance = this;
   }
    void Start() // this is called for play the first song in the playlist
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }
    void Update() // this is called for play the next song in the playlist
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }
    public void PlayNextSong() // this is called for play the next song in the playlist
    {
        index++;
        if (index >= playlist.Length) // for loop the playlist
        {
            index = 0;
        }
        audioSource.clip = playlist[index];
        audioSource.Play();
    }
    public AudioSource PlayClipAt(AudioClip clip , Vector3 pos)  // this is called for play the sound effect in the scene after the  object is destroyed
    {
        GameObject tempGO = new GameObject("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position
        AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
        aSource.clip = clip; // define the clip
        aSource.outputAudioMixerGroup = soundEffectMixer; // set the output to the sound effect mix
        aSource.Play(); // start the sound
        Destroy(tempGO, clip.length); // destroy object after clip duration
        return aSource; // return the AudioSource reference
    }
}
