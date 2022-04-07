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
            StartCoroutine(FadeTitle(1));
        }
    }

    private IEnumerator FadeTitle(float time)
    {
        animator.Play("Fade");
        yield return new WaitForSeconds(time);
        transitioned = true;
        UiManager.Instance.startPanel.SetActive(false);
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

}
