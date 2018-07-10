using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRacket : MonoBehaviour {

    public float sensitivity = 0.3f;
    Rigidbody rb;

	public Transform follow;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();		
	}
	
	void Update()
	{
		Time.fixedDeltaTime = 0.002f;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float mx = -Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime;
        float my = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime;

		follow.position += new Vector3 (0, my, mx);
	}
}
