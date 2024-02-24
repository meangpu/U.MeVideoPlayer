using UnityEngine;
using UnityEngine.Video;
using VInspector;

namespace Meangpu.Video
{
    public class TwoVideoPlayerToggle : BaseVideoPlayer
    {
        // create for make toggle between video that have same length
        [Header("Drag videoClip HERE")]
        [SerializeField] TwoVideoData _videoData;

        public override void UpdateVideo<T>(T newVideo, bool PlayVideoAfterUpdate = true)
        {
            _videoPlayer.clip = newVideo as VideoClip;
            if (PlayVideoAfterUpdate) PlayVideo();
        }

        public void ReplaceNewVideoWithSameFrame(VideoClip newVideo)
        {
            long _currentTime = _videoPlayer.frame;
            _videoPlayer.clip = newVideo;
            _videoPlayer.frame = _currentTime;
        }

        protected override void InitVideoPlayer()
        {
            UpdateVideo(_videoData.GetNowVideo());
        }

        [Button]
        public void ToggleVideo()
        {
            ReplaceNewVideoWithSameFrame(_videoData.GetToggleVideo());
        }
    }
}