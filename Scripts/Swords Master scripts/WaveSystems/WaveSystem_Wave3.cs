using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem_Wave3 : MonoBehaviour
{
    public WaveSystem_Wave2 secondWaveSystem;
    public AddCoins coinManager;
    public GameObject[] enemies;

    public bool _thirdWave;


     void Start()
    {
        _thirdWave = false;
    }

    void Update()
    {
        if (enemies[0] == null && enemies[1] == null && enemies[2] == null && _thirdWave == false)
        {
            _thirdWave = true;
            coinManager.CustomAmountOfCoins(25);
            Debug.Log("Third wave ended!");
        }
    }
    
    void SpawnEnemies()
    {
        enemies[0].SetActive(true);
        enemies[1].SetActive(true);
        enemies[2].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && secondWaveSystem._wave2 == true && _thirdWave == false)
        {
            SpawnEnemies();
        }
    }
}
