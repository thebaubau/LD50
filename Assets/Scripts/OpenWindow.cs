using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenWindow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject windowType;
    [SerializeField] private GameObject windowTitle;
    [SerializeField] private GameObject game;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            Debug.Log("Clicked");
            GameObject window = Instantiate(windowType, transform.parent);
            window.GetComponentInChildren<TextMeshProUGUI>().SetText(windowTitle.GetComponent<TextMeshProUGUI>().text);
            if (game) game.SetActive(true);
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
