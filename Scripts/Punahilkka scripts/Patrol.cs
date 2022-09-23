using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;

    public Transform[] wpoints;

    private int waypointIndex;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wpoints[waypointIndex].position,
            speed * Time.deltaTime);
        
        // Ollaanko tarpeeksi l�hell� vartiointipistett�?
        if (Vector2.Distance(transform.position, wpoints[waypointIndex].position) < 0.1f)
        {
            // Kyll�, joten tarkistetaan ollaanko jo viimeisell� pisteell�?
            if ( waypointIndex < wpoints.Length - 1)
            {
                // Ei olla, joten kerrotaan seuraava vartiointipiste
                waypointIndex++;
            } else
            {
                // Ollaan viimeisess� pisteess�, joten nollataan vartiointi pisteet eli aloitetaan alusta
                waypointIndex = 0;
            }

            ChangeDirection(waypointIndex);
        }
    }

     void ChangeDirection(int wpIndex)
    {
        // Lasketaan suuntavektori
        Vector2 direction = wpoints[wpIndex].transform.position - transform.position;
        // Lasketaan suuntavektorin avulla kulma
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // K��nnet��n kulman arvoa hyv�ksi k�ytt�en AI-hahmo kohti tarkistuspistett�
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
