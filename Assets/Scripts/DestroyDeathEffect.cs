using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDeathEffect : MonoBehaviour
{
    //Animations tiden
    [SerializeField] float animationTime = 0.6f;

    float countDown;
    bool havePlayed = false;

    void Start()
    {
        //S�tter vores countdown til det samme som animation
        countDown = animationTime;
    }


    void Update()
    {
        //S�rger for at den k�rer i time.deltatime, da den ellers ville t�lle ned m�rkeligt.
        countDown -= Time.deltaTime;

        //Vis countDown er det samme eller ligmed 0, og den ikke har spillet animation f�r, s� spiller den animation og slettes efter.
        if (countDown <= 0f && !havePlayed)
        {
            //For at stoppe den med at spille flere gange.
            havePlayed = true;
            Destroy(this.gameObject);
        }
    }
}
