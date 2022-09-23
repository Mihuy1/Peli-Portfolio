using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public GameObject winPanel;

    // Pause
    public static bool gameIsPaused;

    void Update()
    {
        // Esc pääset pois pelistä, päävalikkoon
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Pysäytetään musa
            //AudioManager.instance.StopAll();

            // Peli käynnistyy
            Time.timeScale = 1;

            // Aloitetaan uusi peli
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pysäytetään musa
        //AudioManager.instance.StopAll();

        // Näytetään pelihahmon voittopaneeli
        winPanel.SetActive(true);

        //Pysäytetään peli
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
