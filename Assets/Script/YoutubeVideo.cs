using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace YoutubePlayer
{
public class YoutubeVideo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VideoPlayer>().PlayYoutubeVideoAsync("https://www.youtube.com/watch?v=QNCJZKy8v88");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
