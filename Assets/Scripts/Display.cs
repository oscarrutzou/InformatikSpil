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
    //Til den nuv�rende score
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
        //S�tter b�de liv og score teksten ind p� de rigtige pladser.
        scoreText.text = "Point : " + currentScore.ToString();
        lifeText.text = " Life : " + currentLife.ToString();

        //Starter timeren.
        StartTimer();
    }

    void Update()
    {

        //Hvis den nuv�rende score er st�rre end den gemte highscore, s�tter den nuv�rende score til highscoren.
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            //S�tter highscoren til nuv�rende score.
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
        

        //Hvis timeren er aktiv, skal den t�lle med time.deltaTime for at kunne t�lle rigtigt.
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        //For at kunne se tiden i minutter, sekunder og milisekunder
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerLabel.text = time.ToString(@"mm\:ss\:fff");

        //Hvis liv er 0 s� sendes man videre til Game Over sk�rmen
        if (currentLife == 0)
        {
            TurnOffTimer();

            //Hvis den nuv�rende tid er st�rre end den gemte, s�ttes den til den bedste tid. 
            if (currentTime > PlayerPrefs.GetFloat("BestTime", 0))
            {
                //S�tter den nuv�rende tid til den bedste tid.
                PlayerPrefs.SetFloat("BestTime", currentTime);
            }

            //Hard coded til at loader Game �ver sk�rm
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
        //Tager den nuv�rende score og plusser den med scoren som lige er kommet.
        currentScore += score;
        //S�tter den nuv�rende score til tekst.
        scoreText.text = "Point : " + currentScore.ToString();
    }

    //Bliver kaldt fra TrashDelete sript, for at kunne se om den har ramt en med tagget "Lava".
    public void UpdateLife(int life)
    {
        //Fjerner et liv fra det nuv�rende liv.
        currentLife -= life;
        //S�tter den nuv�rende liv til tekst.
        lifeText.text = " Life : " + currentLife.ToString();
    }
}
