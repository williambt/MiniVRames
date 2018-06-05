using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopCheck : MonoBehaviour
{
    float _time = 0f;
    bool _hit = false;
    bool _done = false;

    ParticleSystem ps;

	// Use this for initialization
	void Start ()
    {
        ps = transform.parent.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!_done)
        {
            if (_hit)
            {
                _time += Time.deltaTime;
            }
            else
            {
                _time = 0f;
            }

            if (_time >= 1f)
            {
                ps.Play();
                _done = true;
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HoopStick")
            _hit = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "HoopStick")
            _hit = false;
    }
}
