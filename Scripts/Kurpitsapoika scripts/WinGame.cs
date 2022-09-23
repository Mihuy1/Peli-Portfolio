using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{

    // Voittopaneeli
    public GameObject winPanel;

    // Pause
    public static bool gameisPaused;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Esc = päävalikko
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Musiikki pysäytyy
            AudioManager.instance.StopAll();

            // Peli käynnistyy
            Time.timeScale = 1;
            // Aloitetaan uusi peli
            SceneManager.LoadScene("MainMenu");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pysäytetään musa
        AudioManager.instance.StopAll();
        // Soitetaan loppufanfaari
        AudioManager.instance.Play("GameWin");
        // Näytetään pelihahmon 2 voittopaneeli 
        winPanel.SetActive(true);
        // Pysäytetään peli
        gameisPaused = !gameisPaused;
        PauseGame();
    }

    void PauseGame()
    {
        if (gameisPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}

