using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject monitorScreen;
    public GameObject powerButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainPanel.activeSelf) return;
        if (powerButton.activeSelf) return;

        //if (!mainPanel.activeSelf)
        //{
        //    powerButton.SetActive(true);
        //}
    }
}
