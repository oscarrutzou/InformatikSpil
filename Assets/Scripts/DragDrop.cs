using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    //Variabler vi skal bruge kunne kaste skrald.
    private float distanceFromCamera;
    Rigidbody2D r;
    //Den skal vises i inspector men ikke skal kaldes af andre scipts.
    [SerializeField] float throwSpeed;
    Vector3 pos;

    void Start()
    {
        //Finder stancen mellem gameobjectet og cameraet.
        distanceFromCamera = Vector3.Distance(this.gameObject.transform.position, Camera.main.transform.position);
        //Finder rigidbody på objectet.
        r = this.gameObject.transform.GetComponent<Rigidbody2D>();
    }    

    //Kaldes når venstreklik er trykket ned.
    void OnMouseDrag()
    {
        //Tager musepositionen
        pos = Input.mousePosition;
        //Til vores vector3 udregning. 
        pos.z = distanceFromCamera;
        //Tager et point på skærmen og finder det rigtige sted i spillet.
        pos = Camera.main.ScreenToWorldPoint(pos);
        //Så objektet følger musen.
        r.velocity = (pos - this.gameObject.transform.position) * 10;
    }

    //Kaldes når man giver slip på venstreklik.
    void OnMouseUp()
    {
        //Stopper kraften.
        r.velocity = Vector3.zero;

        //For at få den til at flyve efter at være kastet.
        r.velocity = (pos - this.gameObject.transform.position) * throwSpeed;
    }
}
