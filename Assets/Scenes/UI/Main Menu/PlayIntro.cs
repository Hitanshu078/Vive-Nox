using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayIntro : MonoBehaviour
{
    VideoPlayer vp;

    void Start() 
    {
        vp = GetComponent<VideoPlayer>();
    }

    public void PlayVid() 
    {
        vp.Play();
    }
}
