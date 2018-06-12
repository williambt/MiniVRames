using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    public GameObject TargetRef;
	void Start ()
    {
        PositionScoreBox(GetRandomPoint());
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PositionScoreBox(GetRandomPoint());
        }
    }
    void PositionScoreBox(Vector3 newPos)
    {
        TargetRef.transform.position = newPos;
    }
    Vector3 GetRandomPoint()
    {
        Vector3 newPos = new Vector3();
        Vector2 random = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        Bounds wallBounds = GetComponent<BoxCollider>().bounds;
        newPos.x = random.x * wallBounds.size.x;
        newPos.y = random.y * wallBounds.size.y;
        
        return wallBounds.min + newPos;
    }
}
