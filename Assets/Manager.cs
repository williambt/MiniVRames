using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour 
{
	public GameObject ball;
	void Start () 
	{
		
	}	
	void Update () 
	{
		var deviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
		if (deviceIndex != -1 && SteamVR_Controller.Input (deviceIndex).GetPressDown (Valve.VR.EVRButtonId.k_EButton_A)) 
		{
			SteamVR_LoadLevel ("PingPong");
		}
		if (deviceIndex != -1 && SteamVR_Controller.Input (deviceIndex).GetPressDown (Valve.VR.EVRButtonId.k_EButton_DPad_Down)) 
		{
			SteamVR_LoadLevel ("PingPong");
		}
	}
}
