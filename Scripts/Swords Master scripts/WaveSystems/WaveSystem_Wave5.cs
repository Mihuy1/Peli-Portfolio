using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem_Wave5 : MonoBehaviour
{
    public WinGame won;

    public WaveSystem_Wave4 waveSystem4;

    public GameObject[] enemies;

    public bool wave5 = false;
    public bool gameWon = false;

    private void Update()
    {
        if (waveSystem4._wave4 == true && enemies[0] == null && enemies[1] == null && enemies[2] == null)
        {
            gameWon = true;
            Debug.Log("game ended");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        enemies[0].SetActive(true);
        enemies[1].SetActive(true);
        enemies[2].SetActive(true);
    }
}
