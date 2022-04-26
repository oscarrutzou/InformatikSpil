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
    //Man beh�ver ikke at lave en rigidbody fordi at scriptet allerede ligger p� traldet.


    //Noget extra hvis der er flere d�dseffekter
    public GameObject deathEffect;

    private Rigidbody2D rb;


    //Den er i Awake, da den skal ske f�r "void Start."
    void Awake()
    {
        //Tilslutter sig "Display" scriptet.
        display = GameObject.FindObjectOfType<Display>();
        //rb2D = gameObject.GetComponent<Rigidbody2D>();
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

            Debug.Log("Point earned");

            GameObject e = Instantiate(deathEffect) as GameObject;

            e.transform.position = transform.position;
            Destroy(this.gameObject);
            //GetComponent<Animator>().Play("BloodExp");            
        }

        if (collision.collider.CompareTag("Lava"))
        {
            Destroy(this.gameObject);
            Debug.Log("Delete");
        }
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("ConveyorBelt"))
        {

            Debug.Log("test");
            rb.velocity = new Vector2(moveSpeed, 0);
            //rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }

    }

}
