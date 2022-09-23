using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string loadGameScene;
    public string newGameScene;

    public GameObject ContinueButton;

    public void Continue() 
    {
        SceneManager.LoadScene(loadGameScene);
        AudioManager.instance.Play("MainMusic");
        AudioManager.instance.StopPlay("MenuMusic");
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
        AudioManager.instance.Play("MainMusic");
        AudioManager.instance.StopPlay("MenuMusic");
    }

    public void Exit()
    {
        Application.Quit();
        AudioManager.instance.Play("MainMusic");
        AudioManager.instance.StopPlay("MenuMusic");
    }
    
}
