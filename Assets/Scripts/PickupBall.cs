using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupBall : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnPoint;

    private Rigidbody _rb;
    private SteamVR_TrackedObject _trackedObj;
    public FixedJoint _joint = null;

    public float accel = 1f;
    public float step = 0.5f;

    public SteamVR_Controller.Device device;
    public SteamVR_TrackedController _controller;

    private bool _touchingSpawner = false;

    // Use this for initialization
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _trackedObj = GetComponent<SteamVR_TrackedObject>();
        _controller = GetComponent<SteamVR_TrackedController>();

        if (_controller != null)
        {
            _controller.TriggerClicked += OnTriggerClick;
            _controller.TriggerUnclicked += OnTriggerUnclick;
        }
    }

    void OnTriggerClick(object sender, ClickedEventArgs e)
    {
        if (_joint == null)
        {
            _joint = Instantiate(ball, spawnPoint.position, spawnPoint.rotation, null).AddComponent<FixedJoint>();
            _joint.connectedBody = _rb;
        }
    }

    void OnTriggerUnclick(object sender, ClickedEventArgs e)
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

    // Update is called once per frame
    void Update()
    {
        if (_controller != null && !_controller.HasHandler("TriggerClicked"))
        {
            _controller.TriggerClicked += OnTriggerClick;
            _controller.TriggerUnclicked += OnTriggerUnclick;
        }
        device = SteamVR_Controller.Input((int)_trackedObj.index);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "BallSpawner")
        {
            ((Behaviour)other.GetComponent("Halo")).enabled = true;
            _touchingSpawner = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "BallSpawner")
        {
            ((Behaviour)other.GetComponent("Halo")).enabled = false;
            _touchingSpawner = false;
        }
    }
}
