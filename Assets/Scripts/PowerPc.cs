using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerPc : MonoBehaviour
{
    [SerializeField] private Button powerPc;
    [SerializeField] private GameObject tutorialPowerPc;
    [SerializeField] private GameObject boot, loading, screen;
    [SerializeField] private AudioClip powerPcAudio;

    [SerializeField] private Button powerMonitor;
    [SerializeField] private GameObject tutorialPowerMonitor;
    [SerializeField] private GameObject monitor;
    [SerializeField] private AudioClip powerMonitorOnAudio;
    [SerializeField] private AudioClip powerMonitorOffAudio;

    private AudioSource audioSource;
    private bool pcState = false;
    private bool monitorState = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TurnPcOnOff()
    {
        if (powerPc.gameObject.activeSelf)
        {
            if (pcState.Equals(false))
            {
                pcState = true;
                //audioSource.clip = powerPcAudio;
                audioSource.PlayOneShot(powerPcAudio);
                powerPc.GetComponent<Image>().enabled = false;
                tutorialPowerPc.SetActive(false);
                StartCoroutine(ButtonCooldown(powerPc));
                StartCoroutine(BootSequence());
            }

            else
            {
                pcState = false;
                audioSource.PlayOneShot(powerPcAudio);
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
                audioSource.PlayOneShot(powerMonitorOnAudio);
                powerMonitor.GetComponent<Image>().enabled = false;
                tutorialPowerMonitor.SetActive(false);
                monitor.SetActive(true);
                StartCoroutine(ButtonCooldown(powerMonitor));
            }

            else
            {
                monitorState = false;
                audioSource.PlayOneShot(powerMonitorOffAudio);
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
