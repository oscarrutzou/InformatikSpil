using UnityEngine.Audio;
using UnityEngine;

//Få at den bliver vist i inspektor
[System.Serializable]
public class Sound
{
    //Giver den en række forskellige ting man kan ændre ved i AudioManageren.
    public string name;
    
    //Kan uploaded clippet.
    public AudioClip clip;

    //Ændre volumen mellem en hvis range.
    [Range(0f,1f)]
    public float volume;
    //Ændre pitchen mellem en hvis range.
    [Range(0.1f,3f)]
    public float pitch;

    //Så man kan loop musikken
    public bool loop;

    //Skal ikke vises i inspectoren
    [HideInInspector]
    public AudioSource sorce;

}
