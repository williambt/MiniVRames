using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ApplyToRacket : MonoBehaviour
{
    public FixedJoint racket;

    private float offset;

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

        racket.transform.rotation *= Quaternion.Euler(offset, 0, 0);
        racket.transform.position = transform.position;
        racket.connectedBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
