using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public bool Paused;
    public GameObject pause;
    public string NewGame;
   


    public static DeathScreen instance;


    public void Start()
    {
        instance = this;
    }

    public void Update()
    {
        if (Paused == false)
        {
            Time.timeScale = 1f;
        }
    }
    public void Pause()
    {
        pause.SetActive(true);
        Paused = true;
        Time.timeScale = 0f;
        print("Paused");
    }


    public void LoadNewGame()
    {
        SceneManager.LoadScene(NewGame);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
