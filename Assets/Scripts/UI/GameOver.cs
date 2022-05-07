using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{
    Display display;

    //Til bedste tid
    public TMPro.TextMeshProUGUI bestTimeText;

    //Til highscore
    public TMPro.TextMeshProUGUI highScoreText;

    float bestTime;

    public void Start()
    {
        highScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        
        bestTime = PlayerPrefs.GetFloat("BestTime");
        bestTimeText.text = "Best Time : " + PlayerPrefs.GetFloat("BestTime", 0).ToString();
        
    }
    public void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(bestTime);
        //Viser tiden i minutter, sekunder og milisekunder
        bestTimeText.text = time.ToString(@"mm\:ss\:fff");


        //Hemmelig knap for at slette ens highscore og besttime.
        if (Input.GetKeyDown(KeyCode.O))
        {
            //Sletter hvad der er i highscore.
            PlayerPrefs.DeleteKey("HighScore");
            //Updater den teksten til at være 0
            highScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
            //Sletter hvad der er i besttime.
            PlayerPrefs.DeleteKey("BestTime");
            //Updater teksten til at være 0.
            highScoreText.text = "BestTime : " + PlayerPrefs.GetFloat("BestTime", 0f).ToString();
        }
    }


    //Kaldes af knap for at starte spillet igen.
    public void TryAgain()
    {
        //Loader den næste i build index
        SceneManager.LoadScene(1);
    }

    //Kaldes af knap for at gå hen til menuen.
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    //Stopper spillet.
    public void QuitGame()
    {
        Application.Quit();
    }
}
