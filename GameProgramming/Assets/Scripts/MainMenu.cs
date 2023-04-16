using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public GameObject settingMenu;
   public void SartGame() // this is called to start a new game
   {
      
      PlayerPrefs.DeleteAll(); // this is called to delete all the playerprefs
      PlayerPrefs.SetString("startLevel", startLevel); // this is called to set the start level
      SceneManager.LoadScene("PreLoad"); 
   }
    public void SettingButton() // this is called to open the setting menu
    {
        settingMenu.SetActive(true);
    }
    public void QuitButton() // this is called to quit the game
    {
        Application.Quit();
    }
    public void BackButton() // this is called to close the setting menu
    {
        settingMenu.SetActive(false);
    }
    public void CreditsButton() // this is called to go to the credits
    {
        SceneManager.LoadScene("credits");
    }
    public void ContinueButton() // this is called to continue the game
    {
        SceneManager.LoadScene("SelectLvl");
    }
}
