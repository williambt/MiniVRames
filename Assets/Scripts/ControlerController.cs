using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControlerController : MonoBehaviour
{
	private Rigidbody _rb;
    public GameObject obj = null;
    private SteamVR_TrackedObject _trackedObj;
    public FixedJoint _joint = null;

	public float accel = 1.33f;
	public float step = 0.5f;

	public SteamVR_Controller.Device device;
	public SteamVR_TrackedController _controller;

    private bool usingAxis = true;
    private bool clicked = false;

    string _axis;

    // Use this for initialization
    void Awake ()
    {
        if (tag == "LeftController")
            _axis = "LeftTrigger";
        else if (tag == "RightController")
            _axis = "RightTrigger";
        _rb = GetComponent<Rigidbody>();
        _trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

    void OnTriggerClick()
    {
        if (_joint == null && obj != null)
        {
            _joint = obj.AddComponent<FixedJoint>();
            _joint.connectedBody = _rb;
        }
    }

    void OnTriggerUnclick()
    {
        if (_joint != null)
        {
            Rigidbody objRB = _joint.gameObject.GetComponent<Rigidbody>();

            DestroyImmediate(_joint);
            _joint = null;

            var origin = _trackedObj.origin ? _trackedObj.origin : _trackedObj.transform.parent;
            if (origin != null)
            {
                objRB.velocity = origin.TransformVector(device.velocity);
                objRB.angularVelocity = origin.TransformVector(device.angularVelocity);
            }
            else
            {
                objRB.velocity = device.velocity;
                objRB.angularVelocity = device.angularVelocity;
            }

            objRB.velocity *= accel;

            objRB.maxAngularVelocity = objRB.angularVelocity.magnitude;
        }
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        device = SteamVR_Controller.Input((int)_trackedObj.index);
		Rigidbody objRB = obj.GetComponent<Rigidbody> ();
      
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            OnTriggerClick();
        }
        else if (_joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            OnTriggerClick();
        }
       

		if (Input.GetKeyDown(KeyCode.F1))
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Pickable")
        {
			if (obj != null && obj != other.gameObject) 
			{
				float distNew = (other.transform.position - transform.position).magnitude;
				float distCurr = (obj.transform.position - transform.position).magnitude;

				if (distNew < distCurr)
					obj = other.gameObject;
			}
			else
				obj = other.gameObject;
        }
    }

	void OnTriggerExit(Collider other)
    {
        if(other.gameObject == obj)
        {
            obj = null;
        }
    }
}
