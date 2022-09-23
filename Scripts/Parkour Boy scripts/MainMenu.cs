using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Käynnistettävän Scenen nimi ( eka taso)
    public string startLevel;

    public void NewGame()
    {
        if (AudioManager.instance != null) AudioManager.instance.Play("Background");
        // Aloitetaan uusi peli
        SceneManager.LoadScene(startLevel);

    }
    
    public void QuitGame()
    {
        // Lopettaa pelin
        Application.Quit();
    }
}
