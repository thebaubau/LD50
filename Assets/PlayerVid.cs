using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerVid : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "loading.mp4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
