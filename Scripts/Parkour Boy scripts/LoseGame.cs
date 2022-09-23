using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{

    [SerializeField] private GameObject GameOverPanel;


    // Start is called before the first frame update
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameOverPanel.SetActive(true);
            SceneManager.LoadScene(0);
        }

    }

    
    // Update is called once per frame
    void Update()
    {
       
    }
}
