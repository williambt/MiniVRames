using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetControllerInfo : MonoBehaviour 
{
	private Text _text;

	public enum Prop { OBJ, JOINT, ACCEL, VEL };

	public ControlerController cc;

	public Prop prop;

	void Awake()
	{
		_text = GetComponent<Text> ();
	}

	void Update () 
	{
		if (prop == Prop.OBJ) {
			if (cc.obj == null)
				_text.text = "null";
			else
				_text.text = cc.obj.name;
		} else if (prop == Prop.JOINT) {
			if (cc._joint == null)
				_text.text = "null";
			else
				_text.text = cc._joint.connectedBody.name;
		} else if (prop == Prop.ACCEL) {
			_text.text = cc.accel.ToString ();
		} else if(cc.device != null) {
			_text.text = cc.device.velocity.ToString ();
		}
	}
}
