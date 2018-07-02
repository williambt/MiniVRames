using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingPongManager : MonoBehaviour
{
    public TextMesh clockRef;
    public PickupBall ballSpawnerRef;

    float Clock = 0;
    bool HasBeenFired = false;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartClock();
        }
        if (HasBeenFired)
        {
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
        int seconds = (int) Clock % 60;
        int minutes =(int) (Clock / 60) % 60;
        clockRef.text = minutes.ToString() + ":" +  seconds.ToString();
    }
}
