using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public AudioSource click;

    public GameObject DeathScreen;
    public GameObject crosshair;

    public void TurnOnScreen()
    {
        DeathScreen.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Main Scene");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClickSound()
    {
        click.Play();
    }
}
