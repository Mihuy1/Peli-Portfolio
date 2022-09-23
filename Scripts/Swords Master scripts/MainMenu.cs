using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource click;
    public AudioSource bgMusic;

    public bool toggle;

    private void Start()
    {
        // Make sure cursor is unlocked and visible.
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        bgMusic.Stop();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ClickSound()
    {
        click.Play();
    }
}
