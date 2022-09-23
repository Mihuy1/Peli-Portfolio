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
        
        // Ollaanko tarpeeksi lähellä vartiointipistettä?
        if (Vector2.Distance(transform.position, wpoints[waypointIndex].position) < 0.1f)
        {
            // Kyllä, joten tarkistetaan ollaanko jo viimeisellä pisteellä?
            if ( waypointIndex < wpoints.Length - 1)
            {
                // Ei olla, joten kerrotaan seuraava vartiointipiste
                waypointIndex++;
            } else
            {
                // Ollaan viimeisessä pisteessä, joten nollataan vartiointi pisteet eli aloitetaan alusta
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
        // Käännetään kulman arvoa hyväksi käyttäen AI-hahmo kohti tarkistuspistettä
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
