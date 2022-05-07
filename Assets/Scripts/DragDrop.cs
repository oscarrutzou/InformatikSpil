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
        //Finder rigidbody p� objectet.
        r = this.gameObject.transform.GetComponent<Rigidbody2D>();
    }    

    //Kaldes n�r venstreklik er trykket ned.
    void OnMouseDrag()
    {
        //Tager musepositionen
        pos = Input.mousePosition;
        //Til vores vector3 udregning. 
        pos.z = distanceFromCamera;
        //Tager et point p� sk�rmen og finder det rigtige sted i spillet.
        pos = Camera.main.ScreenToWorldPoint(pos);
        //S� objektet f�lger musen.
        r.velocity = (pos - this.gameObject.transform.position) * 10;
    }

    //Kaldes n�r man giver slip p� venstreklik.
    void OnMouseUp()
    {
        //Stopper kraften.
        r.velocity = Vector3.zero;

        //For at f� den til at flyve efter at v�re kastet.
        r.velocity = (pos - this.gameObject.transform.position) * throwSpeed;
    }
}
