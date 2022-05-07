using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    //Laver et array ud fra et script.
    public Sound[] sounds;

    //For at der kun kan k�rer en AudioManager.
    public static AudioManager instance;

    void Awake()
    {
        //For at sikre der kun k�rer en AuidoManager.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            //For at sikre at der ikke bliver kaldt mere kode f�r den er slettet.
            return;
        }
        
        //For at den ikke bliver slettet n�r scenerne skifter.
        DontDestroyOnLoad(gameObject);
        
        //Kalder vores Sound script og g�r s� de variabler ren faktisk g�r noget.
        foreach (Sound s in sounds)
        {
            //S� man kan finde hvor musikken er.
            s.sorce = gameObject.AddComponent<AudioSource>();
            s.sorce.clip = s.clip;

            //For at kunne �ndre volume, pitch og sp�rge om den skal v�re i et loop.
            s.sorce.volume = s.volume;
            s.sorce.pitch = s.pitch;
            s.sorce.loop = s.loop;
        }
    }


    void Start()
    {
        //Starter den der hedder "Theme" i vores array.
        Play("Theme");    
    }


    //For at nemmere kunne kalde sounds igennem andre scipts, eller hvis man har mange sounds.
    public void Play(string name)
    {
        //Finder den sound med det samme man har skrevet ind i Play.
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //Hvis man har skrevet forkert, s� fort�ller den det.
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found;(");
            //For at ikke blive ved at s�ge efter den sound.
            return;
        }
        //Starter den sound.
        s.sorce.Play();

    }
}
