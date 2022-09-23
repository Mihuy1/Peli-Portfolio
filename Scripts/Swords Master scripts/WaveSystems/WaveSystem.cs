using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public GameObject[] enemies;
    public AddCoins coinManager;

    public bool _wave1;

     void Awake()
    {
        _wave1 = false;
    }

     void Update()
    {
        if (enemies[0] == null && enemies[1] == null && enemies[2] == null && _wave1 == false)
        {
            Debug.Log("first wave ended");
           _wave1 = true;
            coinManager.CustomAmountOfCoins(20);
            Debug.Log("Your bonus: 20");
        }
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player") && _wave1 == false)
        {
            ActivateWave();
        }
    }

    void ActivateWave()
    {
        enemies[0].SetActive(true);
        enemies[1].SetActive(true);
        enemies[2].SetActive(true);
        Debug.Log("First wave started!");
    }
}
