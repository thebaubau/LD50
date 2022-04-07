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

    [SerializeField] private Button powerLight;
    [SerializeField] private GameObject spotLight;
    [SerializeField] private AudioClip powerOnLamp;
    [SerializeField] private AudioClip powerOffLamp;


    private Color red = new Color(212, 0, 0, 181);
    private Color green = new Color(0, 193, 0, 181);

    private AudioSource audioSource;
    private bool pcState = false;
    private bool monitorState = false;
    private bool lightState = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TurnPcOnOff()
    {
        Image img = powerPc.GetComponent<Image>();

        if (powerPc.gameObject.activeSelf)
        {
            if (pcState.Equals(false))
            {
                pcState = true;
                //audioSource.clip = powerPcAudio;
                audioSource.PlayOneShot(powerPcAudio);
                img.color = green;
                powerPc.transform.Rotate(0, 0, 180);
                tutorialPowerPc.SetActive(false);
                StartCoroutine(BootSequence());
                StartCoroutine(ButtonCooldown(powerPc, 5f));
            }

            else
            {
                pcState = false;
                audioSource.PlayOneShot(powerPcAudio);
                img.color = red;
                powerPc.transform.Rotate(0, 0, -180);
                boot.GetComponent<Image>().enabled = false;
                loading.SetActive(false);
                screen.SetActive(false);
                StartCoroutine(ButtonCooldown(powerPc, 2f));
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
                powerMonitor.GetComponent<Image>().color = green;
                tutorialPowerMonitor.SetActive(false);
                monitor.SetActive(true);
                StartCoroutine(ButtonCooldown(powerMonitor, 1f));
            }

            else
            {
                monitorState = false;
                if (screen.activeSelf) TaskCompletion.Instance.SetTaskComplete(1);
                audioSource.PlayOneShot(powerMonitorOffAudio);
                powerMonitor.GetComponent<Image>().color = red;
                monitor.SetActive(false);
                StartCoroutine(ButtonCooldown(powerMonitor, 1f));
            }
        }
    }

    public void TurnLightOnOff()
    {
        if (powerLight.gameObject.activeSelf)
        {
            if (lightState.Equals(false))
            {
                lightState = true;
                spotLight.SetActive(true);
                audioSource.PlayOneShot(powerOnLamp);
                powerLight.GetComponent<Image>().color = green;
                if (UiManager.Instance.mouseBought)
                {
                    UiManager.Instance.SetBgSprite(UiManager.Instance.bgSprites[0]);
                }
                else
                {
                    UiManager.Instance.SetBgSprite(UiManager.Instance.bgSprites[1]);
                }

                StartCoroutine(ButtonCooldown(powerLight, .5f));
            }

            else
            {
                lightState = false;
                spotLight.SetActive(false);
                audioSource.PlayOneShot(powerOffLamp);
                powerLight.GetComponent<Image>().color = red;
                if (screen.activeSelf)
                {
                    TaskCompletion.Instance.SetTaskComplete(6);
                }

                if (UiManager.Instance.mouseBought)
                {
                    UiManager.Instance.SetBgSprite(UiManager.Instance.bgSprites[2]);
                }
                else
                {
                    UiManager.Instance.SetBgSprite(UiManager.Instance.bgSprites[3]);
                }
                StartCoroutine(ButtonCooldown(powerLight, .5f));
            }
        }
    }

    private IEnumerator ButtonCooldown(Button button, float seconds)
    {
        button.interactable = false;
        yield return new WaitForSeconds(seconds);
        button.interactable = true;
    }

    private IEnumerator BootSequence()
    {
        boot.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(5);
        boot.GetComponent<Image>().enabled = false;
        loading.SetActive(true);

        yield return new WaitForSeconds(5);
        loading.SetActive(false);
        screen.SetActive(true);
    }

}
