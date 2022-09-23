using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio; // Travitaan ��nen kanssa

[System.Serializable] // N�kyy Inspectorissa
public class Sound
{

    // ��ni
    public AudioClip clip;

    // ��nen nimi
    public string name;

    //Liukukytkimet
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    // Merkkilippu joka kertoo soitetaanko ��ni loopissa
    public bool loop;

    //��nen l�hde, joka piilotetaan
    [HideInInspector]
    public AudioSource source; // AudioManager k�ytt�� t�t� muuttujaa
} // Sound.cs p��ttyy
