using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRacket : MonoBehaviour {

    public float sensitivity = 0.3f;

    Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float mx = Input.GetAxis("Mouse X") * sensitivity;
        float my = Input.GetAxis("Mouse Y") * sensitivity;

        rb.MovePosition(transform.position + new Vector3(mx, my, 0));

        //transform.Translate(new Vector3(mx, my, 0), Space.World);
	}
}
