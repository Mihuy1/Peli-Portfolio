using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

// Puzzlen luokan tehtäviä on
// deaktivoida kytkin ja käynnistää pulma
// suorittaa kytkin animaatio sekä portin aukaisu animaatio
public class Puzzle : MonoBehaviour
{

    // Tapahtuma, joka käynnistyy kun törmätään porttiin.
    public UnityEvent OnPuzzle;

    // Animaattorit
    private Animator switchAnim; // Kytkimen animaattori
    [SerializeField] private Animator gateAnim; // Portin animaatio
    // Start is called before the first frame update
    void Start()
    {
        switchAnim = GetComponent<Animator>();
    }

    // Pulmaan liitetty triggeri, joka käynnistyy pelaajan toimesta.
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Deaktivoi kytkimen kollaiderin
            GetComponent<BoxCollider2D>().enabled = false;
            // Tapahtuma (pulman kysymys) on käynnistetty, Pulmakontrolleri voi nyt käsitellä pulman
            OnPuzzle?.Invoke();
        }
    }


    public void HandleAnimations(int _puzzleID)
    {
        AudioManager.instance.Play("SwitchAnim");
        // Käynnistää pulmaan liittyvät animaatiot
        switch (_puzzleID)
        {
            // Pulma 1
            case 1:
                switchAnim.SetTrigger("SwitchLaserOn");
                gateAnim.SetTrigger("GateDown1");
                break;
            // Pulma 2
            case 2:
                switchAnim.SetTrigger("SwitchLaserOn");
                gateAnim.SetTrigger("GateDown1");
                break;
            case 3:
                switchAnim.SetTrigger("SwitchLaserOn");
                gateAnim.SetTrigger("GateDown1");
                break;

            case 4:
                switchAnim.SetTrigger("SwitchLaserOn");
                gateAnim.SetTrigger("GateDown1");
                break;
            // Ei tehdä mitään
            default:
                break;
        }
    }

    public void Deactivate()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
