using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayError : MonoBehaviour
{
    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
