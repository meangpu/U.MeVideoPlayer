using UnityEngine;
using UnityEngine.Video;

namespace Meangpu.Video
{
    public class VideoPlayerVideoClip : VideoPlayerBase
    {
        [Header("Drag videoClip HERE")]
        [SerializeField] protected VideoClip _video;

        public override void UpdateVideo<T>(T newVideo)
        {
            _videoPlayer.clip = newVideo as VideoClip;
            PlayVideo();
        }

        protected override void InitVideoPlayer()
        {
            _videoPlayer.clip = _video;
            _rawImg.texture = _mainTexture;
            _videoPlayer.targetTexture = _mainTexture;
        }
    }
}