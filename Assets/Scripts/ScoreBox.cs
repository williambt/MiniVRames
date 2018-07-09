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

    int lastID = -1;
    int consecutiveHits = 0;
    float multiplier = 1.0f;
    int ceiling = 4;
    public float Score { get; private set; }

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
        if (collision.gameObject.tag == "Ball")
        {
            if (collision.gameObject.GetComponent<BallTest>().GetID() == lastID) // se for a mesma bola que bate adiciona a um multiplicador
            {
                consecutiveHits++;
                Debug.Log(consecutiveHits.ToString());
                if (consecutiveHits > ceiling)
                {
                    ceiling += ceiling;
                    multiplier += 0.5f;
                }
            }
            else
            {
                lastID = collision.gameObject.GetComponent<BallTest>().GetID();
                ceiling = 4;
                consecutiveHits = 1;
                multiplier = 1.0f;
            }

            if (!PingPongManager.Instance.timeUp)
            {
                ScoreCalculation(collision.contacts[0].point, TargetRef.transform.position);
                PositionScoreBox(GetRandomPoint());
            }
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
            score *= multiplier;
        }
        UpdateScoreboard((int)score);

    }
    void UpdateScoreboard(int deltaScore)
    {
        Score += deltaScore;
        ScoreboardRef.GetComponent<TextMesh>().text = Score.ToString();
    }
    void UpdateMultiplier()
    {

    }
}
