using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDeathEffect : MonoBehaviour
{
    public float animationTime = 0.6f;

    float countDown;
    bool havePlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        countDown = animationTime;
    }


    void FixedUpdate()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0f && !havePlayed)
        {
            //For at stoppe den med at spille flere gange.
            havePlayed = true;
            Destroy(this.gameObject);
        }
    }
}
