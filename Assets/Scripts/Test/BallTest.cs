using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTest : MonoBehaviour
{
    Vector3 _startPos;

    float _colTimer = 0;
    public float timeout = 4f;

    int id = -1;

    Joint _joint;
    Rigidbody rigidbodyRef;
    //idealmente eu faria o audio em uma classe separada, mas precisa ser rapido
    AudioSource ballSource;
    public AudioClip bounceClip;
    public AudioClip tableBounceClip;

    void Start ()
    {
        _joint = GetComponent<Joint>();
        _startPos = transform.position;
        ballSource = gameObject.AddComponent<AudioSource>();
        ballSource.clip = bounceClip;
        ballSource.loop = false;
        rigidbodyRef = GetComponent<Rigidbody>();
	}
	
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
        PlaySound(other);
    }
    void Reset()
    {
        Destroy(gameObject);
    }
    public void SetID(int newId)
    {
        id = newId;
    }
    public int GetID()
    {
        return id;
    }
    void PlaySound(Collision other)
    {
        float mag = rigidbodyRef.velocity.magnitude;
        mag = Mathf.Clamp(mag, 0.5f, 1.5f);
        ballSource.volume = 0.5f * mag;
        ballSource.pitch = Random.Range(0.9f, 1.1f);
        if (other.gameObject.name == "Table")
        {
            ballSource.clip = tableBounceClip;
            ballSource.Play();
        }
        else
        {
            ballSource.clip = bounceClip;
            ballSource.pitch = Random.Range(0.8f, 1.2f);
            ballSource.Play();
        }
    }
}
