﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Racket : MonoBehaviour {

	Rigidbody rb;
	public Transform follow;
    public float offset = 90f;

	// Use this for initialization
	void Start () 
	{
        try
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "\\offset"))
            {
                string line = sr.ReadToEnd();
                offset = float.Parse(line);
            }
        }
        catch
        {
            Application.Quit();
        }

		rb = GetComponent<Rigidbody> ();
	}
	
    void Update()
    {
        Time.fixedDeltaTime = 0.002f;
    }

    // Update is called once per frame
    void FixedUpdate () 
	{
		rb.MovePosition (follow.position);
		rb.MoveRotation (follow.rotation * Quaternion.Euler(offset, 0, 0));
	}
}
