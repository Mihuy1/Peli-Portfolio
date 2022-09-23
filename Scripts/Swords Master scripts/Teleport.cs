using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public WaveSystem_Wave3 waveSystem;

    public GameObject player;
    public Transform location;

    bool tped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && waveSystem._thirdWave != false)
        {
            player.transform.position = location.position;
            tped = true;
        }
    }
}
