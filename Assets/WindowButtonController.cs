using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowButtonController : MonoBehaviour
{ 
    private Image buttonImage;
    private NavigationController navigationController;
    private bool focused = false;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        navigationController = NavigationController.Instance;
    }

    public void ChangeButtonState(bool state)
    {
        if (state.Equals(true)) 
        {
            focused = true;
            buttonImage.sprite = navigationController.buttonPressed;
            Debug.Log("Focused");
        }
        else
        {
            focused = false;
            buttonImage.sprite = navigationController.buttonNotFocused;
            Debug.Log("Unfocused");
        }
    }

    public void Focused()
    {
        if (focused)
        {
            ChangeButtonState(false);
        }
        else
        {
            ChangeButtonState(true);
        }
    }
}
