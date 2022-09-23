using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    // ƒ‰nil‰hteet sis‰lt‰v‰ oliotaulukko
    public Sound[] sounds;

    // Vain yksi esiintym‰ (sinkelton)
    public static AudioManager instance;

     void Start()
    {
        Play("MainMusic");
    }

    void Awake()
    {
        // Onko AudioManageri olemassa
        if (instance == null)
        {
            // AudioManager ei ole olemassa, joten luodaan se
            instance = this;
        } else
        {
            // AudioManager on jo olemassa, joten tuhotaan se
            Destroy(gameObject);

            // Varmistetaan ett‰ muuta koodia ei en‰‰ suoriteta
            return;
        }
        // ƒl‰ tuoha gameobjektia ladattaessa.
        DontDestroyOnLoad(gameObject);

        // N‰ytt‰‰ oliotaulukon kaikki ‰‰nil‰hteet
        foreach (Sound s in sounds)
        {
            // Yhteys ‰‰nil‰hteeseen
            s.source = gameObject.AddComponent<AudioSource>();

            // ƒ‰ni joka halutaan soittaa
            s.source.clip = s.clip;

            // P‰ivitt‰‰ tehdyt s‰‰dˆt Audio-komponenttiin
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    // Soittaa halutun ‰‰nen
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        
        if (s == null) return;

        s.source.Play();
    }

    public void StopPlay(string name)
    {
        // Esitet‰‰n haluttu ‰‰ni
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // Onko ‰‰nt‰ olemassa
        if (s == null) return;
        s.source.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
