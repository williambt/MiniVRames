using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ApplyToRacket : MonoBehaviour
{
    public FixedJoint racket;

    private float offset;
    private bool setToOwn;

	// Use this for initialization
	void Start ()
    {
        try
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "\\offset"))
            {
                string line = sr.ReadLine();
                if (line == "own")
                {
                    setToOwn = true;
                    print("own");
                }
                else
                {
                    setToOwn = false;
                    print("notown");
                }
                line = sr.ReadLine();
                offset = float.Parse(line);
                print(offset);
            }
        }
        catch
        {
            Application.Quit();
        }

        racket.transform.position = transform.position;
        racket.transform.rotation = (setToOwn ? transform.rotation : racket.transform.rotation) * Quaternion.Euler(offset, 0, 0);
        racket.connectedBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
