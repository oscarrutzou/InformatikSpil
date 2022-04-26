using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class DestroyDeathEffect : MonoBehaviour
{
    public float animationTime = 0.6f;

    float countDown;
    bool havePlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        countDown = animationTime;
        Debug.Log("Viker det" + countDown + ", " + animationTime);
        //Destroy(this.gameObject);
    }


    void FixedUpdate()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0f && !havePlayed)
        {
            Debug.Log("Viker");
            //For at stoppe den med at spille flere gange.
            havePlayed = true;
            Destroy(this.gameObject);
        }
    }
}
