using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    private float distanceFromCamera;
    Rigidbody2D r;
    public float speed;
    Vector3 pos;

    void Start()
    {
        distanceFromCamera = Vector3.Distance(this.gameObject.transform.position, Camera.main.transform.position);
        r = this.gameObject.transform.GetComponent<Rigidbody2D>();
    }
    //Evt. brug eller slet
    

    void OnMouseDrag()
    {
        pos = Input.mousePosition;
        pos.z = distanceFromCamera;
        pos = Camera.main.ScreenToWorldPoint(pos);
        r.velocity = (pos - this.gameObject.transform.position) * 10;
    }

    void OnMouseUp()
    {
        r.velocity = Vector3.zero;

        //For at få den til at flyve efter at være kastet
        r.velocity = (pos - this.gameObject.transform.position) * speed;
    }



    //    //Virker ved venstre klik
    //    if (Input.GetMouseButtonDown(0))


}
