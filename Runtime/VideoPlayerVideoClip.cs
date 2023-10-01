using UnityEngine;
using UnityEngine.Video;

namespace Meangpu.Video
{
    public class VideoPlayerVideoClip : VideoPlayerWithUI
    {
        [Header("Drag videoClip HERE")]
        [SerializeField] protected VideoClip _video;

        protected override void InitVideoPlayer()
        {
            _videoPlayer.clip = _video;
            _rawImg.texture = _mainTexture;
            _videoPlayer.targetTexture = _mainTexture;
        }
    }
}