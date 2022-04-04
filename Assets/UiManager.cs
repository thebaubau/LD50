using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject taskList;

    public TextMeshProUGUI winningQuote;

    private string[] quotes = new string[]
    {
        "They say procrastinators are perfectionists. Well, I say better to be late and perfect than on time and average",
        "Warning: Tackling a difficult project after returning to work from a holiday weekend can cause dizziness, extreme resentment, and low self-esteem.",
        "Postponement is the first step in acknowledging that something at hand needs to get done... eventually.",
        "Wouldn't it be great if money were as easy to make as it is to spend?",
        "If you feel guilty about doing nothing at the end of the day, you have procrastinated improperly. Begin again tomorrow with a better attitude.",
        "If you search \"psychology of procrastination\" online, you'll notice a lot of experts have too much time on their hands."

    };

    private static UiManager instance;

    public static UiManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UiManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if all task are complete trigger win screen
    }

    public void Win()
    {
        StartCoroutine(WinGame());
    }

    private IEnumerator WinGame()
    {
        winningQuote.text = quotes[UnityEngine.Random.Range(0, quotes.Length - 1)];
        // Play animation to show winning quote
        // yield animation time
        // show restart button
        yield return null;
    }
}
