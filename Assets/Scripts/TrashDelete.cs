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

    //Laver en variable så man kan kontakte "Display" scriptet.
    Display display;

    //Noget extra hvis der er flere dødseffekter
    public GameObject deathEffect;

    private Rigidbody2D rb;



    //Den er i Awake, da den skal ske før "void Start."
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

    //Når den rammer noget, bliver metoden kaldt.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Hvis den rammer en maskrine, bliver objektet slettet.
        if (collision.collider.CompareTag("Machine"))
        {
            //Sender scoren af objektet til "Display scriptet"
            display.UpdateScore(score);

            //Spawner en dødseffekt.
            GameObject e = Instantiate(deathEffect) as GameObject;
            //Sætter dødseffekten til den samme position som skraldet.
            e.transform.position = transform.position;
            //Ødelægger skraldet.
            Destroy(this.gameObject);
        }

        //Når den rammer laver, mister man liv.
        if (collision.collider.CompareTag("Lava"))
        {
            //Updater liv
            display.UpdateLife(life);

            //Send videre til gameover skærm når man har 0 liv
            if (life == 0)
            {
                //Slukker timer
                display.TurnOffTimer();
            }
            //Ødelægger skraldet.
            Destroy(this.gameObject);
        }
    }

    //Når den er ovenpå conveyorbeltet bliver den skubbet hen af x-aksen.
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ConveyorBelt"))
        {
            //Bliver sendt hen af x-asken.
            rb.velocity = new Vector2(conveyorBeltSpeed, 0);
        }
    }
}
