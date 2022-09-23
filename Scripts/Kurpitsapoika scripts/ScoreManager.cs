using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    // Reseptipalojen lukumäärä
    private int recepieAmmount;

    // Canvaksessa oleva tekstilaatikko, joka näyttää kerätyt reseptipalat.
    [SerializeField]
    private Text recepieCounterText;
    private void Awake()
    {
        // Nollataan resepti laskuri pelin alussa
        recepieAmmount = 0;
    }

    // Oven suojacollaideri
    public GameObject wallCollider;

    private void Update()
    {
        // Tulostetaan kerättyjen reseptipalojen lukumäärä konsoliin.
        recepieCounterText.text = recepieAmmount.ToString() + " / 8";

        // Tutkitaan onko reseptin paloja kerätty tarpeeksi
        if (recepieAmmount == 4)
        {
            // Poistetaan oven suojacollaideri
            wallCollider.SetActive(false);
        }

    }

    public void AddRecepie()
    {
        recepieAmmount++;
    }
}

