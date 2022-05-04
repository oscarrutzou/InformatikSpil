using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            //For at sikre at der ikke bliver kaldt mere kode før den er slettet
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {
            s.sorce = gameObject.AddComponent<AudioSource>();
            s.sorce.clip = s.clip;

            s.sorce.volume = s.volume;
            s.sorce.pitch = s.pitch;
            s.sorce.loop = s.loop;
        }
    }


    void Start()
    {
        Play("Theme");    
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found;(");
            return;
        }
        s.sorce.Play();

    }
}
