using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    public GameObject TargetRef;

    public GameObject ScoreboardRef;

    public float MaxPoints = 100;
    public float MinPoints = 10;
    public float MaxDistance = 10;

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
    private void OnCollisionEnter(Collision collision)
    {
        print("Alfafa");
        if (collision.gameObject.name == "Ball")
        {
            ScoreCalculation(collision.contacts[0].point, TargetRef.transform.position);
            PositionScoreBox(GetRandomPoint());
        }
    }
    void ScoreCalculation(Vector3 hitPos, Vector3 scoreCenterPos)
    {
        float dist = Vector3.Distance(hitPos, scoreCenterPos);
        float factor = dist / MaxDistance;
        float score = 0;
        if (factor < 1)
        {
            if (factor <= 0.2f)
            {
                score = MaxPoints;
            }
            else if (factor <= 0.4f)
            {
                score = MaxPoints / 2;
            }
            else if (factor <= 0.6f)
            {
                score = MaxPoints / 3;
            }
            else if (factor <= 0.8f)
            {
                score = MaxPoints / 4;
            }
            else if (factor <= 1.0f)
            {
                score = MaxPoints / 5;
            }
        }
        UpdateScoreboard((int)score);

    }
    void UpdateScoreboard(int deltaScore)
    {
        ScoreboardRef.GetComponent<TextMesh>().text = deltaScore.ToString();
    }
}
