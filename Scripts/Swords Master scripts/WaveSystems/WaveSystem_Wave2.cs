using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem_Wave2 : MonoBehaviour
{
    public WaveSystem firstWaveSystem;
    public AddCoins coinManager;
    public GameObject[] enemies;

    public bool _wave2;

     void Start()
    {
        _wave2 = false;
    }

    void Update()
    {
        if (enemies[0] == null && enemies[1] == null && enemies[2] == null && enemies[3] == null && _wave2 == false)
        {
            _wave2 = true;
            coinManager.CustomAmountOfCoins(20);
            Debug.Log("Second wave ended!");
            Debug.Log("You got second wave reward!");
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && firstWaveSystem._wave1 == true && _wave2 == false)
        {
            ActivateWave2();
        }
    }

    void ActivateWave2()
    {
        enemies[0].SetActive(true);
        enemies[1].SetActive(true);
        enemies[2].SetActive(true);
        enemies[3].SetActive(true);
        Debug.Log("Second wave started!");
    }
}
