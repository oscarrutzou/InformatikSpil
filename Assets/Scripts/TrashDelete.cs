using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDelete : MonoBehaviour
{

    public float moveSpeed = 5;
    //Til hvor meget score de hver objekter har.
    public int score;
    //Laver en variable s� man kan kontakte "Display" scriptet.
    private Display display;
    public Rigidbody2D rb2D;
    public float thrust = 1f;

    //Den er i Awake, da den skal ske f�r "void Start."
    void Awake()
    {
        //Tilslutter sig "Display" scriptet.
        display = GameObject.FindObjectOfType<Display>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
       // m_Rigidbody = GetComponent<Rigidbody>();
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

        if (collision.collider.CompareTag("ConveyorBelt"))
        {
            Debug.Log("test");
            rb2D.velocity = new Vector2(0, 10);
        }

    }

}
