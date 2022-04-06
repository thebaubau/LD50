using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool transitioned = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (transitioned) return;
            animator.SetTrigger("Transition");
            transitioned = true;
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

}
