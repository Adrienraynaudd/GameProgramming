
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TextMeshProUGUI text;
    public Slider musicSlider;
   public Slider soundEffectSlider;
    public void Start()
    {
      audioMixer.GetFloat("Music", out float musicValueForSlider); // this is called to get the value of the music volume
      musicSlider.value = musicValueForSlider;

      audioMixer.GetFloat("SEffect", out float soundEffectValueForSlider); // this is called to get the value of the sound effect volume
      soundEffectSlider.value = soundEffectValueForSlider;

      resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray(); // this is called to get the resolution of the screen
      resolutionDropdown.ClearOptions();
      List<string> options = new List<string>();
      int currentResolutionIndex = 0;
      for (int i = 0; i < resolutions.Length; i++)
      {
         string option = resolutions[i].width + " x " + resolutions[i].height;
         options.Add(option);
         if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
         {
            currentResolutionIndex = i;
         }
      }
      resolutionDropdown.AddOptions(options);
      resolutionDropdown.value = currentResolutionIndex;
      resolutionDropdown.RefreshShownValue();
      text.text = Screen.width + " x " + Screen.height;
      Screen.fullScreen = true;
    }
   public void SetVolumeMusic(float volume) // this is called to set the volume of the music
   {
      audioMixer.SetFloat("Music", volume);
   }
   public void SetVolumeSoundEffect(float volume) // this is called to set the volume of the sound effect
   {
      audioMixer.SetFloat("SEffect", volume);
   }

   public void SetFullScreen(bool isFullScreen) // this is called to set the screen to full screen
   {
      Screen.fullScreen = isFullScreen;
   }
    public void SetResolution(int resolutionIndex) // this is called to set the resolution of the screen
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
         text.text = resolution.width + " x " + resolution.height;
    }
}
