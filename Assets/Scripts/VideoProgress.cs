using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoProgress : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    private Slider slider;
    private RectTransform sliderRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        sliderRectTransform = slider.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.frameCount > 0)
        {
            slider.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    private void TrySkip(PointerEventData eventData)
    {
        var frame = videoPlayer.frameCount * slider.value;
        videoPlayer.frame = (long)frame;
    }
}
