using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Display : MonoBehaviour
{
    //Til point
    //Henter den specielle Tekst pakke.
    public TMPro.TextMeshProUGUI scoreText;
    //Til den nuværende score
    private int currentScore;
    
    //Til timeren
    bool timerActive = false;
    float currentTime;
    public TMPro.TextMeshProUGUI timerLabel;

    void Start()
    {
        currentTime = 0;

        //Slet efter have lavet UI
        StartTimer();
    }

    void Update()
    {
        //Til timeren
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        //Viser tiden i minutter, sekunder og milisekunder
        timerLabel.text = time.ToString(@"mm\:ss\:fff");

    }

    public void StartTimer()
    {
        timerActive = true;
    }
    public void TurnOffTimer()
    {
        timerActive = false;
    }

    //Denne bliver kaldt hver gang et objekt rammer en ting med tagget "maksine".
    public void UpdateScore(int score)
    {
        //Tager den nuværende score og plusser den med scoren som lige er kommet.
        currentScore += score;
        scoreText.text = "Point : " + currentScore.ToString();
    }

}
