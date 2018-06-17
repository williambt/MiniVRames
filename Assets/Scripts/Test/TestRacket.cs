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
        float mx = -Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float my = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rb.MovePosition(transform.position + new Vector3(0, my, mx));
	}
}
