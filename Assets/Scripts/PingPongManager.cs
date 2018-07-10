using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingPongManager : MonoBehaviour
{
    public static PingPongManager Instance { get; private set; }

    public TextMesh clockRef;
    public PickupBall ballSpawnerRef;

    public EndScreen endScreen;

    AudioSource audiosrc;

    float Clock = 0;
    bool HasBeenFired = false;
    bool counting = true;

    public float time = 60.0f;

    bool blinkOn = true;
    public float blinkTime = 1.0f;
    float blinkTimer = 0.0f;
    bool blinkEntireDisplay = false;

    public bool timeUp { get; private set; }

    void Awake()
    {
        Instance = this;
    }

	void Start ()
    {
        audiosrc = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        if(Clock >= time && !timeUp)
        {
            timeUp = true;
            audiosrc.Play();
            counting = false;
            blinkTime = 0.33f;
            blinkEntireDisplay = true;
            endScreen.ShowScreen();
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartClock();
        }
        if (HasBeenFired)
        {
            if(counting)
                Clock += Time.deltaTime;

            UpdateBoard();
        }	
	}
    public void StartClock()
    {
        if (!HasBeenFired)
        {
            Clock = 0;
            HasBeenFired = true;
        }
    }
    void UpdateBoard()
    {
        int seconds = (int)Clock % 60;
        int minutes = (int)(Clock / 60) % 60;
        if(!blinkEntireDisplay)
            clockRef.text = minutes.ToString() + (blinkOn ? ":" : " ") + seconds.ToString();
        else
        {
            if (blinkOn)
                clockRef.text = minutes.ToString() + ":" + seconds.ToString();
            else
                clockRef.text = "";
        }

        blinkTimer += Time.deltaTime;
        if (blinkTimer > blinkTime)
        {
            blinkOn = !blinkOn;
            blinkTimer = 0.0f;
        }
    }
}
