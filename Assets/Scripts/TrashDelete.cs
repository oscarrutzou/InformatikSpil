using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashDelete : MonoBehaviour
{

    [SerializeField] float conveyorBeltSpeed = 5;
    //Til hvor meget score de hver objekter har.
    public int score;

    //Til liv
    public int life = 1;

    //Laver en variable s� man kan kontakte "Display" scriptet.
    Display display;

    //Noget extra hvis der er flere d�dseffekter
    public GameObject deathEffect;

    private Rigidbody2D rb;



    //Den er i Awake, da den skal ske f�r "void Start."
    void Awake()
    {
        //Tilslutter sig "Display" scriptet.
        display = GameObject.FindObjectOfType<Display>();
    }

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
            rb = GetComponent<Rigidbody2D>();
       
    }

    //N�r den rammer noget, bliver metoden kaldt.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Hvis den rammer en maskrine, bliver objektet slettet.
        if (collision.collider.CompareTag("Machine"))
        {
            //Sender scoren af objektet til "Display scriptet"
            display.UpdateScore(score);

            //Spawner en d�dseffekt.
            GameObject e = Instantiate(deathEffect) as GameObject;
            //S�tter d�dseffekten til den samme position som skraldet.
            e.transform.position = transform.position;
            //�del�gger skraldet.
            Destroy(this.gameObject);
        }

        //N�r den rammer laver, mister man liv.
        if (collision.collider.CompareTag("Lava"))
        {
            //Updater liv
            display.UpdateLife(life);

            //Send videre til gameover sk�rm n�r man har 0 liv
            if (life == 0)
            {
                //Slukker timer
                display.TurnOffTimer();
            }
            //�del�gger skraldet.
            Destroy(this.gameObject);
        }
    }

    //N�r den er ovenp� conveyorbeltet bliver den skubbet hen af x-aksen.
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ConveyorBelt"))
        {
            //Bliver sendt hen af x-asken.
            rb.velocity = new Vector2(conveyorBeltSpeed, 0);
        }
    }
}
