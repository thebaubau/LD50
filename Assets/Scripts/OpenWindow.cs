using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenWindow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject windowType;
    [SerializeField] private GameObject windowTitle;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            //windowTitle = GetComponentInChildren<TextMeshProUGUI>();
            GameObject videoWindow = Instantiate(windowType, transform.parent);
            videoWindow.GetComponentInChildren<TextMeshProUGUI>().SetText(windowTitle.GetComponent<TextMeshProUGUI>().text);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
