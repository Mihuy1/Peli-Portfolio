using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Kirjastot
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    public Image logo;
    private Color logoColor;

    public float lerpMultiplier = 0.2f;

    private int timeToWait = 6;
    // Start is called before the first frame update
    void Start()
    {
        logoColor = new Color(1, 1, 1, 0);
        logo.color = logoColor;

        // Alirutiini kutsu
        StartCoroutine(GotoMainMenuCo());

        // Taustamusiikki
        AudioManager.instance.StopPlay("MainMusic");
        AudioManager.instance.Play("MenuMusic");
    }

    IEnumerator GotoMainMenuCo()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("MainMenu");;
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.instance.StopPlay("MainMusic");
        logoColor = Color.Lerp(logoColor, new Color(1, 1, 1, 1), Time.time * lerpMultiplier);
        logo.color = logoColor;
    }


}
