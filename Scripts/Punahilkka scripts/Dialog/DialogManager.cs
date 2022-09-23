using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    // UI referenssit
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    // Dialogi referenssi
    private string[] dialogLines;
    private int currentLine = 0;
    private bool justStarted;
    public float typingSpeed;
    private bool isCoroutingRunning;

    // Dialogi instanssi
    public static DialogManager instance;
    // Start is called before the first frame update
    void Start()
    {
        // Onko DialogManager olemassa?
        if (instance == null)
        {
            // Ei ole joten luodaan DialogManager esiintym‰
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire2") && !isCoroutingRunning && justStarted)
        {
            // Siirryt‰‰n seuraavalle riville
            currentLine++;
            // Onko dialogi jo p‰‰ttynyt
            if (currentLine >= dialogLines.Length)
            {
                // Dialogi on p‰‰ttynyt, joten suljetaan dialogi-ikkuna
                dialogBox.SetActive(false);

                GameManager.instance.dialogActive = false;
            }
            else 
            {
                CheckIfName();

                StartCoroutine(AutoType(dialogLines, currentLine)); // Automaattikirjoitus
            }
            
        }
    }
    public void showDialog(string[] newLines, bool isPerson)
    {
        // Montako tekstiriv‰ dialogissa on
        dialogLines = newLines;

        // Aloitetaan 1. tekstist‰
        currentLine = 0;

        // Tarkistetaan dialogiin osallistuvan nimi, jos on hahmo
        CheckIfName();

        // n‰ytet‰‰n dialogi-ikkuna
        dialogBox.SetActive(true);

        // N‰ytet‰‰n dialogin 1. rivi (0. rivi k‰yty, jos oli henkilˆ)
        // dialogText.text = dialogLines[currentLine];
        StartCoroutine(AutoType(dialogLines, currentLine));

        // Ilmoitetaan Update-funktiolle ett‰ dialogi ikkuna on aukaistu
        justStarted = true;

        // Aktivoidaan tai deaktivoidaan nimilaatikko
        nameBox.SetActive(isPerson);

        // Informoidaan GameManageria ett‰ dialogi on k‰ynniss‰
        GameManager.instance.dialogActive = true;
    }

    private void CheckIfName() 
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");

            // Hyp‰t‰‰n seuraavalle riville
            currentLine++;
        }
    
    }

    public void StopDialog() 
    {
        // Suljetaan dialogi ikkuna
        dialogBox.SetActive(false);

        // Informoidaan GameManageria ett‰ dialogi on p‰‰ttynyt
        GameManager.instance.dialogActive = false;
    }

    IEnumerator AutoType(string[] newLines, int _currentLine)
    {
        // Tyhjennet‰‰n dialogi
        dialogText.text = "";

        // Kerrotaan Update-metodille, ett‰ automaattikirjoitus on k‰ynniss‰
        isCoroutingRunning = true;

        // Keskustelua ei voi jatkaa
        justStarted = false;

        // K‰yd‰‰n dialogin rivi l‰pi kirjain kerralaan
        foreach (char letter in newLines[_currentLine].ToCharArray())
        {
            // Lis‰t‰‰n seuraava kirjain
            dialogText.text += letter;

            // Odotetaan pieni hetki
            yield return new WaitForSeconds(typingSpeed);
        }

        isCoroutingRunning = false;

        justStarted = true;
    }

}
