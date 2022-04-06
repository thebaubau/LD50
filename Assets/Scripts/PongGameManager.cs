using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PongGameManager : MonoBehaviour
{
    private int PlayerScore1 = 0;
    private int PlayerScore2 = 0;

    [SerializeField]private TextMeshProUGUI playerOneScoreText;
    [SerializeField]private TextMeshProUGUI playerTwoScoreText;

    private static PongGameManager instance;

    public static PongGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PongGameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    instance = obj.AddComponent<PongGameManager>();
                }
            }
            return instance;
        }
    }

    GameObject theBall;

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    public void Score(string wallID)
    {
        if (wallID == "Right Wall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
        UpdateScore();
    }

    public void UpdateScore()
    {
        playerOneScoreText.text = PlayerScore1.ToString();
        playerTwoScoreText.text = PlayerScore2.ToString();
        if (PlayerScore1 == 10 || PlayerScore2 == 10)
        {
            TaskCompletion.Instance.SetTaskComplete(5);
        }
    }

    public void RestartGame()
    {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
    }
}
