using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHoop : MonoBehaviour
{

    public GameObject hoop;

    private bool pressed = false;
    	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetAxis("LeftGrip") > 0.5f || Input.GetAxis("RightGrip") > 0.5f) && !pressed)
        {
            Instantiate(hoop, transform.position, transform.rotation, null);
            pressed = true;
        }
        else if (Input.GetAxis("LeftGrip") < 0.5f && Input.GetAxis("RightGrip") < 0.5f && pressed)
        {
            pressed = false;
        }
	}
}
