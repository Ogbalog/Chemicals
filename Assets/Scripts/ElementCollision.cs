using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]




//Checks if elements collide with the holders, if they do, snaps them to their location,
public class ElementCollision : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GameObject holderLeft;
    private GameObject holderRight;
    BoxCollider2D holderLeftCollider;
    BoxCollider2D holderRightCollider;
    public Elementmovement elementmovement;
    reaction reaction;
    // Start is called before the first frame update
    void Start()
    {
        elementmovement = GetComponent<Elementmovement>();
        //Initialise Collision Components, and set them up
        holderLeft = GameObject.FindGameObjectWithTag("Holder1");
        holderRight = GameObject.FindGameObjectWithTag("Holder2");
        holderLeftCollider = GameObject.FindGameObjectWithTag("Holder1").GetComponent<BoxCollider2D>();
        holderRightCollider = GameObject.FindGameObjectWithTag("Holder2").GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb2d.gravityScale = 0;

    }
    void OnTriggerEnter2D(Collider2D col){
        
        if(col == holderLeftCollider) {
            //If component is in the left box, set its position there
            transform.position = holderLeft.transform.position;
            elementmovement.isSelectable = false;   

        
        }




        if (col == holderRightCollider){
             //If component is in the right box, set its position there
            transform.position = holderRight.transform.position;
            elementmovement.isSelectable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
