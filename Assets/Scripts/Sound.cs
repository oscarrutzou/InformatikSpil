using UnityEngine.Audio;
using UnityEngine;

//Få at den bliver vist i inspektor
[System.Serializable]
public class Sound
{
    public string name;
    
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource sorce;

}
