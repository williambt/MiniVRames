using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public ControlerController[] controllers;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            SteamVR_LoadLevel.Begin("GabrielTest");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SteamVR_LoadLevel.Begin("Hoops");
        }

        foreach (ControlerController c in controllers)
        {
            if(c._joint != null)
            {
                if(c._joint.gameObject.name == "Hoop")
                {
                    SteamVR_LoadLevel.Begin("Hoops");
                }
                else if (c._joint.gameObject.name == "Racket")
                {
                    SteamVR_LoadLevel.Begin("GabrielTest");
                }
            }
        }
	}
}
