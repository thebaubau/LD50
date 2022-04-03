using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public Button play;
    public Button pause;
    public VideoPlayer videoPlayer;

    public void PlayVideo()
    {
        videoPlayer.Play();
        
        play.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
        play.gameObject.SetActive(true);
        pause.gameObject.SetActive(false);
    }
}
