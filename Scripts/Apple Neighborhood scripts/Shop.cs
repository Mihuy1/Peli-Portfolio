using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public bool GameIsPaused;

    public GameObject pause;

    public GameObject AppleCounter;

    public GameObject HPBar;

    public GameObject WindowHPBar;

    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.P))
       // {
          //  if (GameIsPaused)
         //   {
                //Resume();
          //  } else
         //   {
         //       Pause();
          //  }
      //  }
    }

        //public void Pause()
        //{
           // GameIsPaused = true;
           // pause.SetActive(true);
           // Time.timeScale = 0f;
           // print("Pause");

       // }

       // public void Resume()
       // {
          //  GameIsPaused = false;
           // pause.SetActive(false);
           // Time.timeScale = 1f;
           // print("Resume");
        //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pause.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pause.SetActive(false);
        }
    }
}
