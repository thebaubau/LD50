using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    private Vector2 lastMousePosition;
    private Vector2 currentMousePosition;
    private Vector2 offset;
    private Vector3 oldPosition, newPosition;
    private RectTransform rect = null;
    private RectTransform canvasRect = null;
    
    private GameObject canvas = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
        rect = GetComponent<RectTransform>();
        rect.SetAsLastSibling();
        canvas = GameObject.FindGameObjectWithTag("UI Canvas");
        canvasRect = canvas.GetComponent<RectTransform>();
        //Debug.Log(canvasRect.name + " canvas rect");
        //Debug.Log(canvasRect.rect.position.x);
        //Debug.Log(canvasRect.rect.position.y);
        //Debug.Log(canvasRect.anchoredPosition.x);
        //Debug.Log(canvasRect.anchoredPosition.y);
        //Debug.Log(canvasRect.rect.width);
        //Debug.Log(canvasRect.rect.height);

        //Vector2 hitLocation = new Vector2();
        //currentMousePosition = eventData.worldPosition;
        //currentMousePosition = eventData.pointerCurrentRaycast.screenPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentMousePosition = eventData.position;

        //Vector2 hitLocation = new Vector2();
        //currentMousePosition = eventData.worldPosition;
        //currentMousePosition = eventData.pointerCurrentRaycast.screenPosition;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //    canvasRect, Input.mousePosition, Camera.main, out hitLocation);

        //currentMousePosition = hitLocation;

        //Debug.Log(currentMousePosition + " current mouse pos");
        offset = currentMousePosition - lastMousePosition;
        //rect = GetComponent<RectTransform>();

        //Debug.Log(rect.name + " rect");
        newPosition = rect.position + new Vector3(offset.x / 2, offset.y / 2, 0);
        //newPosition = currentMousePosition;
        oldPosition = rect.position;

        //Debug.Log(oldPosition + " old position");
        //Debug.Log(newPosition + " new position");

        rect.position = newPosition;
        //Debug.Log(rect.position + " rect position");

        if (!IsRectTransformInsideSreen(rect))
        {
            //rect.position = oldPosition;
        }

        lastMousePosition = currentMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rect.SetAsLastSibling();
    }

    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        bool isInside = false;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        //rectTransform.GetLocalCorners(corners);
        int visibleCorners = 0;
        Rect rect = new Rect(0, 0, canvasRect.rect.width, canvasRect.rect.height);
        //Rect rect = new Rect(0, 0, 1280, 1024);

        foreach (Vector3 corner in corners)
        {
            if (rect.Contains(corner))
            {
                visibleCorners++;
            }
        }
        if (visibleCorners == 4)
        {
            isInside = true;
        }
        return isInside;
    }
}
