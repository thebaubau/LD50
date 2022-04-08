using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private TextMeshProUGUI timer;
    private int duration = 600;
    private int startingHour = 9;
    private bool isCountingDown = false;

    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        StartTimer();
    }

    private void StartTimer()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            Invoke("UpdateClock", 60f);
        }
    }

    private void UpdateClock()
    {
        duration -= 60;
        Debug.Log(duration);
        if (duration > 0)
        {
            Invoke("UpdateClock", 60f);

            timer.text = (startingHour += 1).ToString() + ":00";
        }
        else
        {
            isCountingDown = false;
            UiManager.Instance.Win();
        }
    }
}
