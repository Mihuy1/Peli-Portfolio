using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Amogus1;
    public string LoadGameScene;
    public string CharacterSelect;

    public void StartGame()
    {
        SceneManager.LoadScene(LoadGameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Characters()
    {
        SceneManager.LoadScene(CharacterSelect);
    }

    public void Amogus()
    {
        SceneManager.LoadScene(Amogus1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
