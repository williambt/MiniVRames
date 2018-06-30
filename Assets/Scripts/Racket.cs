using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {

	Rigidbody rb;
	public Transform follow;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rb.MovePosition (follow.position);
		rb.MoveRotation (follow.rotation);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(-90, 0, 0));
	}
}
