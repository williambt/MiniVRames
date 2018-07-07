using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private float timeShowed;
    public float duration = 0.33f;

    private bool opening = false;

    public ScoreBox scoreBox;
    private TextMesh text;

	// Use this for initialization
	void Start ()
    {
        transform.localScale = Vector3.zero;
        TextMesh[] childrenText = GetComponentsInChildren<TextMesh>();
        foreach (TextMesh tm in childrenText)
            if (tm.name == "Score") text = tm;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.localScale.x < 1f && opening)
        {
            float val = Time.deltaTime / duration;
            transform.localScale += new Vector3(val, val, val);
        }
	}

    public void ShowScreen()
    {
        timeShowed = Time.time;
        opening = true;
        text.text = scoreBox.Score.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        {
            BallTest bt = other.gameObject.GetComponent<BallTest>();
            if(bt.lastHitTime > timeShowed)
            {
                SteamVR_LoadLevel.Begin("GabrielTest");
            }
        }
    }
}
