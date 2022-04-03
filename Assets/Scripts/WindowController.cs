using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowController : MonoBehaviour
{
    private Button button;
    private WindowButtonController windowButtonController;

    private void OnEnable()
    {
        button = NavigationController.Instance.AssignButton();
        windowButtonController = button.gameObject.GetComponent<WindowButtonController>();
    }

    public void MinimizeWindow()
    {
        //gameObject.SetActive(false);
        //windowButtonController.ChangeButtonState(false);
    }

    public void CloseWindow()
    {
        button.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
