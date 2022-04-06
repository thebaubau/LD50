using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    public GameObject[] windowButtons;
    public Sprite buttonPressed;
    public Sprite buttonNotFocused;

    private static NavigationController instance;

    public static NavigationController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NavigationController>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    instance = obj.AddComponent<NavigationController>();
                }
            }
            return instance;
        }
    }

    public Button AssignButton()
    {
        foreach (GameObject windowButton in windowButtons)
        {
            if (windowButton.activeSelf) continue;
            // if all buttons are enabled, throw and error

            if (!windowButton.activeSelf)
            {
                //windowButton.SetActive(true);
                //windowButton.GetComponent<WindowButtonController>().ChangeButtonState(true);
                //return windowButton.GetComponent<Button>();
            }   
        }
        return null;
    }
}
