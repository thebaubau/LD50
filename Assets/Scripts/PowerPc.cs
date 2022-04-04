using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerPc : MonoBehaviour
{
    [SerializeField] private Button powerPc;
    [SerializeField] private GameObject tutorialPowerPc;
    [SerializeField] private GameObject boot, loading, screen;

    [SerializeField] private Button powerMonitor;
    [SerializeField] private GameObject tutorialPowerMonitor;
    [SerializeField] private GameObject monitor;

    private bool pcState = false;
    private bool monitorState = false;

    public void TurnPcOnOff()
    {
        if (powerPc.gameObject.activeSelf)
        {
            if (pcState.Equals(false))
            {
                pcState = true;
                powerPc.GetComponent<Image>().enabled = false;
                tutorialPowerPc.SetActive(false);
                StartCoroutine(ButtonCooldown(powerPc));
                StartCoroutine(BootSequence());
            }

            else
            {
                pcState = false;
                boot.GetComponent<Image>().enabled = false;
                loading.GetComponent<Image>().enabled = false;
                screen.SetActive(false);
            }
        }
    }

    public void TurnMonitorOnOff()
    {
        if (powerMonitor.gameObject.activeSelf)
        {
            if (monitorState.Equals(false))
            {
                monitorState = true;
                powerMonitor.GetComponent<Image>().enabled = false;
                tutorialPowerMonitor.SetActive(false);
                monitor.SetActive(true);
                StartCoroutine(ButtonCooldown(powerMonitor));
            }

            else
            {
                monitorState = false;
                monitor.SetActive(false);
            }
        }
    }

    private IEnumerator ButtonCooldown(Button button)
    {
        button.interactable = false;
        yield return new WaitForSeconds(5);
        button.interactable = true;
    }

    private IEnumerator BootSequence()
    {
        boot.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(5);
        boot.GetComponent<Image>().enabled = false;
        loading.GetComponent<Image>().enabled = true;
        // trigger camera animation
        CameraController.Instance.ZoomIn();
        yield return new WaitForSeconds(5);
        loading.GetComponent<Image>().enabled = false;
        screen.SetActive(true);
    }

}
