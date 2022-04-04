using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator animator;
    private static CameraController instance;

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

    public void ZoomIn()
    {
        animator.SetTrigger("ZoomIn");
    }



}
