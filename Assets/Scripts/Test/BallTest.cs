using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTest : MonoBehaviour
{

    //Rigidbody rb;
    Vector3 _startPos;

    float _colTimer = 0;
    public float timeout = 4f;

    Joint _joint;

	// Use this for initialization
	void Start ()
    {
        //rb = GetComponent<Rigidbody>();
        _joint = GetComponent<Joint>();
        _startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Time.fixedDeltaTime = 0.002f;

        if(_joint == null)
        {
            _colTimer += Time.deltaTime;
            if(_colTimer >= timeout)
            {
                Reset();
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            _colTimer = 0;
        }
        /*else if (other.gameObject.name == "Floor")
        {
            Reset();
        }*/
    }

    void Reset()
    {
        Instantiate(gameObject, _startPos, transform.rotation, null).name = "Ball";
        Destroy(gameObject);
    }
}
