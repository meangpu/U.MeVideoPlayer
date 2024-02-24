using UnityEngine;
using UnityEngine.Video;

namespace Meangpu.Video
{
    public class VideoPlayerVideoClip : BaseVideoPlayer
    {
        [Header("Drag videoClip HERE")]
        [SerializeField] protected VideoClip _video;

        public override void UpdateVideo<T>(T newVideo, bool PlayVideoAfterUpdate = true)
        {
            _videoPlayer.clip = newVideo as VideoClip;
            if (PlayVideoAfterUpdate) PlayVideo();
        }

        protected override void InitVideoPlayer()
        {
            UpdateVideo(_video, false);
        }
    }
}