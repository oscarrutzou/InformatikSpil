using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{


    
    private float distanceFromCamera;
    Rigidbody2D r;

    void Start()
    {
        distanceFromCamera = Vector3.Distance(this.gameObject.transform.position, Camera.main.transform.position);
        r = this.gameObject.transform.GetComponent<Rigidbody2D>();
    }
    //Evt. brug eller slet
    //Vector3 lastPos;

    void OnMouseDrag()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = distanceFromCamera;
        pos = Camera.main.ScreenToWorldPoint(pos);
        r.velocity = (pos - this.gameObject.transform.position) * 10;
    }
    void OnMouseUp()
    {
        r.velocity = Vector3.zero;
    }



    //    //Virker ved venstre klik
    //    if (Input.GetMouseButtonDown(0))


}
