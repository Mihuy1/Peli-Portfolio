using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class pauseMenuUI : MonoBehaviour
{
 
    public bool GameIsPaused;

    public GameObject pause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (GameIsPaused) 
            {
                Resume();
            } else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        print("Resume");
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        print("Pause");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameIsPaused = false;
        Time.timeScale = 1f;
        AudioManager.instance.StopPlay("MainMusic");
        AudioManager.instance.Play("MenuMusic");
    }
}
