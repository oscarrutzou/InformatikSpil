using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class Display : MonoBehaviour
{
    //Til point
    //Henter den specielle Tekst pakke.
    public TMPro.TextMeshProUGUI scoreText;
    //Til den nuværende score
    [HideInInspector]
    public int currentScore;

    //Til timeren
    bool timerActive = false;
    float currentTime = 0;
    public TMPro.TextMeshProUGUI timerLabel;

    //Til liv
    public TMPro.TextMeshProUGUI lifeText;
    [SerializeField] int currentLife = 10;

    void Start()
    {
        //Sætter både liv og score teksten ind på de rigtige pladser.
        scoreText.text = "Point : " + currentScore.ToString();
        lifeText.text = " Life : " + currentLife.ToString();

        //Starter timeren.
        StartTimer();
    }

    void Update()
    {

        //Hvis den nuværende score er større end den gemte highscore, sætter den nuværende score til highscoren.
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            //Sætter highscoren til nuværende score.
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
        

        //Hvis timeren er aktiv, skal den tælle med time.deltaTime for at kunne tælle rigtigt.
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        //For at kunne se tiden i minutter, sekunder og milisekunder
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerLabel.text = time.ToString(@"mm\:ss\:fff");

        //Hvis liv er 0 så sendes man videre til Game Over skærmen
        if (currentLife == 0)
        {
            TurnOffTimer();

            //Hvis den nuværende tid er større end den gemte, sættes den til den bedste tid. 
            if (currentTime > PlayerPrefs.GetFloat("BestTime", 0))
            {
                //Sætter den nuværende tid til den bedste tid.
                PlayerPrefs.SetFloat("BestTime", currentTime);
            }

            //Hard coded til at loader Game Óver skærm
            SceneManager.LoadScene(2);
        }
    }

    //Starter timeren
    public void StartTimer()
    {
        timerActive = true;
    }

    //Slukker timeren
    public void TurnOffTimer()
    {
        timerActive = false;
    }

    //Denne bliver kaldt hver gang et objekt rammer en ting med tagget "maksine".
    public void UpdateScore(int score)
    {
        //Tager den nuværende score og plusser den med scoren som lige er kommet.
        currentScore += score;
        //Sætter den nuværende score til tekst.
        scoreText.text = "Point : " + currentScore.ToString();
    }

    //Bliver kaldt fra TrashDelete sript, for at kunne se om den har ramt en med tagget "Lava".
    public void UpdateLife(int life)
    {
        //Fjerner et liv fra det nuværende liv.
        currentLife -= life;
        //Sætter den nuværende liv til tekst.
        lifeText.text = " Life : " + currentLife.ToString();
    }
}
