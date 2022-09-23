using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    // Tehdään luokasta staattinen jotta sitä voidaan käyttää muista koodeista
    public static PuzzleController instance;

    // Pulman käynnistävät kytkimet talletetaan taulukkoon
    [SerializeField] Puzzle[] puzzles;

    // Canvas - Matemaattinen tehtävä
    [SerializeField] private GameObject puzzlePanel; // Paneeli
    [SerializeField] private Text questionText; // Matemaattinen tehtävä
    [SerializeField] private Button Answer1Button; // Vastauspainike 1
    [SerializeField] private Button Answer2Button; // VastausPainike 2
    [SerializeField] private Button Answer3Button; // VastausPainike 3
    [SerializeField] private Text answer1Text; // Painikkeen 1 teksti
    [SerializeField] private Text answer2Text; // Painikkeen 2 teksti
    [SerializeField] private Text answer3Text; // Painikkeen 3 teksti
    // Start is called before the first frame update
    void Start()
    {
        // otetaan staattinen luokka käyttöön.
        instance = this;
        puzzlePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// käynnistää pulman käsittelyn
    /// <param name="_puzzleID"></param>

    public void HandlePuzzle(int _puzzleID)
    {
        // Estetään pelihahmon liikkuminen
        PlayerController.instance.MyCanMove = false;

        // Siirrytään idle-animaatioon
        PlayerController.instance.MyAnim.SetFloat("Speed", 0);
        PlayerController.instance.MyAnim.SetBool("Grounded", true);

        // Näytä matemaattinen tehtävä
        puzzlePanel.SetActive(true);
        switch (_puzzleID)
        {
            case 1:
                // pelihahmo on osunut kytkimeen 1, joten käynnstetään puzzle 1
                //puzzles[1].HandleAnimations(1);
                ShowProblem1();
                    break;
            case 2:
                // pelihahmo on osunut kytkimeen 2, joten käynnistetään puzzle 2
                ShowProblem2();
                break;
            case 3:
                ShowProblem3();
                break;
            case 4:
                ShowProblem4();
                    break;
            default:
                // ei mitään
                break;


        }
    }
    public void ShowProblem1()
    {
        questionText.text = "4 - 0 = _"; // Matemaattinen tehtävä
        Answer1Button.name = "2"; // oikea painike
        answer1Text.text = "4"; // oikea vastaus

        Answer2Button.name = "Wrong";  // Väärä painike
        answer2Text.text = "3";

        Answer3Button.name = "Wrong";   // Väärä painike
        answer3Text.text = "8";
        
    }
    public void ShowProblem2()
    {
        questionText.text = "20 - 12 = _";
        Answer1Button.name = "2";
        answer1Text.text = "8";

        Answer2Button.name = "Wrong";
        answer2Text.text = "10";

        Answer3Button.name = "Wrong";
        answer3Text.text = "9";
    }
    public void ShowProblem3()
    {

        questionText.text = "10 - 10 = _";
        Answer1Button.name = "3";
        answer1Text.text = "0";


        Answer2Button.name = "Wrong";
        answer2Text.text = "10";



        Answer3Button.name = "Wrong";
        answer3Text.text = "9";
    }
    public void ShowProblem4()
    {

        questionText.text = "5 + 25 = _";
        Answer1Button.name = "4";
        answer1Text.text = "30";


        Answer2Button.name = "Wrong";
        answer2Text.text = "10";


        Answer3Button.name = "Wrong";
        answer3Text.text = "9";
    }



    /// Pelaaja painaa vastauspainiketta
    /// Oikea vastaus painike, tunnistetaan painikkeen nimen mukaan
    /// Painikeet on nimetty 1, 2, 3 jne.
    /// <param name="button"></param>
    public void HandleCorrectAnswer(Button button)
    {
        switch(button.name)
        {
            case "1":
                // oikea vastaus tehtävässä 1
                StartCoroutine(CheckAnswerCO(1));
                break;

            case "2":
                // oikea vastaus tehtävässä 2
                StartCoroutine(CheckAnswerCO(2));
                break;
            case "3":
                // Oikea vastaus tehtävässä 3
                StartCoroutine(CheckAnswerCO(3));
                break;
            case "4":
                StartCoroutine(CheckAnswerCO(4));
                    break;
            default:
                // Väärä vastaus tehtävään
                StartCoroutine(CheckAnswerCO(0));
                break;

        }
    }

    /// Näyttää, että on kaksi sekunttia
    /// Vastaus on väärin jos _puzzleID = 0
    /// <param name="_puzzleID"></param>
    
    private IEnumerator CheckAnswerCO(int _puzzleID)
    {

        Answer1Button.interactable = false;
        Answer2Button.interactable = false;
        Answer3Button.interactable = false;
        if (_puzzleID == 0)
        {
            questionText.text = "VÄÄRIN!";
        }

        else
        {
            questionText.text = "OIKEIN!";
            // Käännetään kytkin yksi auki
            puzzles[_puzzleID].Deactivate();
            puzzles[_puzzleID].HandleAnimations(_puzzleID);
        }
        // Odotetaan 2 sekunttia
        yield return new WaitForSeconds(2f);

        Answer1Button.interactable = true;
        Answer2Button.interactable = true;
        Answer3Button.interactable = true;


        // Piilotetaan paneeli
        puzzlePanel.SetActive(false);
        // Pelihahmo voi liikkua
        PlayerController.instance.MyCanMove = true;
    }
}

