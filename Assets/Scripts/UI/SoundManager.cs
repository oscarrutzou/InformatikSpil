using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //For at kunne finde vores slider
    [SerializeField] Slider volumeSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        //Hvis brugeren ikke har r�rt ved volume, s� spiller musikken med fuld kraft.
        //Ellers loader den deres settings.
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        //S�tter volume til valuen p� slideren og laver en save.
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        //S�tter den lig med hvad vi har gemt
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        //S�tter value fra slider ind i vores key name
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
