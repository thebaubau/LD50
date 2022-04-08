using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAi : MonoBehaviour
{
    public float speed = 5f;
    public float boundY = 3f;
    public GameObject ball;
    private Vector3 paddlePos;
    private Vector3 ballPos;

    void Update()
    {
        paddlePos = transform.position;
        ballPos = ball.transform.position;

        transform.position = new Vector3(
            transform.position.x,
            Mathf.MoveTowards(paddlePos.y, ballPos.y, speed + Time.deltaTime),
            transform.position.z);
    }
}
