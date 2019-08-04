using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string FirstSceneName = "FirstGameplayScene";

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Health", 3);
        SceneManager.LoadScene(FirstSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
