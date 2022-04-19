using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDelete : MonoBehaviour
{
    //Til hvor meget score de hver objekter har.
    public int score;
    //Laver en variable s� man kan kontakte "Display" scriptet.
    private Display display;


    //Den er i Awake, da den skal ske f�r "void Start."
    void Awake()
    {
        //Tilslutter sig "Display" scriptet.
        display = GameObject.FindObjectOfType<Display>();
    }


    //N�r den rammer noget, bliver metoden kaldt.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Hvis den rammer en maskrine, bliver objektet slettet.
        if (collision.collider.CompareTag("Machine"))
        {
            Destroy(this.gameObject);

            //Sender scoren af objektet til "Display scriptet"
            display.UpdateScore(score);


            //Lav s� den starter en animation n�r den d�r.
        }

        if (collision.collider.CompareTag("Lava"))
        {
            Destroy(this.gameObject);

        }

    }

}
