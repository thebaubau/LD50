using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerMonitor : MonoBehaviour
{
    [SerializeField] private Button powerMonitor;
    [SerializeField] private GameObject tutorialPowerMonitor;
    [SerializeField] private GameObject monitor;

    private bool monitorState = false;

    public void TurnMonitorOnOff()
    {
        if (powerMonitor.gameObject.activeSelf)
        {
            if (monitorState.Equals(false))
            {
                monitorState = true;
                tutorialPowerMonitor.SetActive(false);
                monitor.SetActive(true);
                StartCoroutine(MonitorButtonCooldown(powerMonitor));
            }

            else
            {
                monitorState = false;
                monitor.SetActive(false);
            }
        }
    }

    private IEnumerator MonitorButtonCooldown(Button button)
    {
        button.interactable = false;
        yield return new WaitForSeconds(2);
        button.interactable = true;
    }

}
