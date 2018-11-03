using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

    public float rotationSpeed = 2f;
    public float movementSpeed = -0.02f;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {

        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        
            transform.Rotate(Vector3.forward * rotationSpeed);
            rb2d.velocity = new Vector2(-movementSpeed, 0);
        
         


    }

}
