
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
      audioMixer.GetFloat("Music", out float musicValueForSlider);
      musicSlider.value = musicValueForSlider;

      audioMixer.GetFloat("SEffect", out float soundEffectValueForSlider);
      soundEffectSlider.value = soundEffectValueForSlider;

      resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
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
   public void SetVolumeMusic(float volume)
   {
      audioMixer.SetFloat("Music", volume);
   }
   public void SetVolumeSoundEffect(float volume)
   {
      audioMixer.SetFloat("SEffect", volume);
   }

   public void SetFullScreen(bool isFullScreen)
   {
      Screen.fullScreen = isFullScreen;
   }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
