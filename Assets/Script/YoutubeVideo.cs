using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace YoutubePlayer
{
    public class YoutubeVideo : MonoBehaviour
    {
        public string url;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<VideoPlayer>().PlayYoutubeVideoAsync(url);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
