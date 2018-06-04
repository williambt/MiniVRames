using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControlerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject obj = null;
    private SteamVR_TrackedObject _trackedObj;
    private FixedJoint _joint = null;

    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        _trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var objRB = obj.GetComponent<Rigidbody>();
        var device = SteamVR_Controller.Input((int)_trackedObj.index);
        if(_joint == null && obj != null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            _joint = obj.AddComponent<FixedJoint>();
            _joint.connectedBody = rb;
        }
        else if (_joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            DestroyImmediate(_joint);
            _joint = null;

            var origin = _trackedObj.origin ? _trackedObj.origin : _trackedObj.transform.parent;
            if(origin != null)
            {
                objRB.velocity = origin.TransformVector(device.velocity);
                objRB.angularVelocity = origin.TransformVector(device.angularVelocity);
            }
            else
            {
                objRB.velocity = device.velocity;
                objRB.angularVelocity = device.angularVelocity;
            }

            objRB.maxAngularVelocity = objRB.angularVelocity.magnitude;
        }
	}

    void OnCollisionEnter(Collider other)
    {
        if (other.tag == "Pickable")
        {
            obj = other.gameObject;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject == obj)
        {
            obj = null;
        }
    }
}
