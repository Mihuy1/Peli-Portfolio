using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    // Käynnissä oleva aika
    private float currentTime = 0f;

    // Aloitus aika
    [SerializeField] private float startingTime = 0f;

    // Tekstilaatikko jossa aika näytetään
    [SerializeField] private Text countdownTimerText;

    // Tekstin väri
    private Color color = new Color(1, 1, 1, 1);
    // Start is called before the first frame update

    [SerializeField] private GameObject gameOverPanel;
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartCounting();
    }
    void StartCounting()
    {
        // Aloitetaan vähentämään aikaa
        currentTime -= Time.deltaTime;

        // Varmistetaan, että aika ei mene alle 0:00
        currentTime = Mathf.Clamp(currentTime, 0f, Mathf.Infinity);

        // Päivitetään aika
        countdownTimerText.text = DisplayTime(currentTime);

        // Ajastimen väri
        countdownTimerText.color = color;

        // Jos aikaa on enää 10 sekunttia väri vaihtuu
        if (currentTime <= 10)
        {
            // Väri vaihtuu
            color = new Color(255, 0, 0, 1);

            // Tähän lisätään ääni

            // Loppuiko aika?
            if (currentTime <= 0)
            {
                // Nollataan aika
                currentTime = 0;

                // GameOver
                StartCoroutine(GameOver());
            }
        }
    }

    // Muuttaa sekunnit minuuteiksi ja sekunneiksi ja palauttaa ajan kutsujalle

    private string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return "Aika " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private IEnumerator GameOver()
    {
        // Näytetään GameOver Paneeli
        gameOverPanel.SetActive(true);
        // Odotetaan 2 sekunttia
        yield return new WaitForSeconds(2);
        // Piilotetaan
        gameOverPanel.SetActive(false);
        // Aloitetaan peli alusta
        SceneManager.LoadScene(0);
    }
}
