using UnityEngine;
using UnityEngine.Video;

namespace Meangpu.Video
{
    public class VideoPlayerVideoClip : VideoPlayerWithUI
    {
        [Header("Drag video from 'StreamingAssets' HERE")]
        [SerializeField] protected VideoClip _video;

        protected override void InitVideoPlayer()
        {
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, _video.name);
            _rawImg.texture = _mainTexture;
            _videoPlayer.targetTexture = _mainTexture;
        }
    }
}