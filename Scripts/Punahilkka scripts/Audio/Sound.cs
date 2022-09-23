using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio; // Travitaan äänen kanssa

[System.Serializable] // Näkyy Inspectorissa
public class Sound
{

    // Ääni
    public AudioClip clip;

    // Äänen nimi
    public string name;

    //Liukukytkimet
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    // Merkkilippu joka kertoo soitetaanko ääni loopissa
    public bool loop;

    //Äänen lähde, joka piilotetaan
    [HideInInspector]
    public AudioSource source; // AudioManager käyttää tätä muuttujaa
} // Sound.cs päättyy
