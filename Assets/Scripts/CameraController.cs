using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator animator;
    private static CameraController instance;
    private float currentTime;
    private float timeOver;
    private float timeUnder;

    private bool scroolingUp = false;
    private bool scroolingDown = true;


    [SerializeField] private AnimationClip cameraZoomInOut;

    public static CameraController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CameraController>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f) timeOver = 1f;

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0f) timeUnder = 0f;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (scroolingUp)
            {
                animator.StopPlayback();
                scroolingUp = false;
                scroolingDown = true;
                Debug.Log("Scroll up");
                //animator.StartPlayback();
                //animator.speed = 1f;
                animator.SetFloat("Direction", -1); 
                animator.Play("Zoom In", 0, timeOver);
            }

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (scroolingDown)
            {
                animator.StopPlayback();
                scroolingUp = true;
                scroolingDown = false;
                Debug.Log("Scroll down");
                //animator.StartPlayback();
                //animator.speed = -1f;
                animator.SetFloat("Direction", 1);
                animator.Play("Zoom In", 0, timeUnder);
            }
        }
    }

    private IEnumerator AnimationWait()
    {
        yield return new WaitForSeconds(1);

    }

    public void ZoomIn()
    {
        animator.SetTrigger("ZoomIn");
    }



}
