using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 lastMousePosition;
    private Vector2 currentMousePosition;
    private Vector2 offset;
    private Vector3 oldPosition, newPosition;
    private RectTransform rect = null;
    private RectTransform canvasRect = null;
    Canvas canvas = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
        canvas = GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();
        Debug.Log(canvasRect.name + " canvas rect");
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentMousePosition = eventData.position;
        offset = currentMousePosition - lastMousePosition;
        rect = GetComponent<RectTransform>();
        Debug.Log(rect.name + " rect");
        newPosition = rect.position + new Vector3(offset.x, offset.y, 0);
        oldPosition = rect.position;
        rect.position = newPosition;

        if (!IsRectTransformInsideSreen(rect))
        {
            //rect.position = oldPosition;
        }

        lastMousePosition = currentMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        bool isInside = false;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        int visibleCorners = 0;
        Rect rect = new Rect(canvasRect.rect.position.x, canvasRect.rect.position.y, canvasRect.rect.width, canvasRect.rect.height);

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
