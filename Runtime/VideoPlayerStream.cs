using UnityEditor;
using UnityEngine;

namespace Meangpu.Video
{
    public class VideoPlayerStream : VideoPlayerWithUI
    {
        [Header("Drag video from 'StreamingAssets' HERE")]
        [SerializeField] protected DefaultAsset _video;

        protected override void InitVideoPlayer()
        {
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, _video.name);
            _rawImg.texture = _mainTexture;
            _videoPlayer.targetTexture = _mainTexture;
        }
    }
}