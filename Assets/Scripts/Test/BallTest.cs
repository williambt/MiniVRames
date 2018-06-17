using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTest : MonoBehaviour
{

    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnCollisionEnter(Collision other)
    {
        print("Alfafa");
        if (other.gameObject.tag == "Player")
        {
            rb.useGravity = true;
        }
    }
}
