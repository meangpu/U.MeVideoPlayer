using UnityEngine;
using UnityEngine.Video;
using VInspector;

namespace Meangpu.Video
{
    public class VideoPlayerTwoVideoToggle : BaseVideoPlayer
    {
        // create for make toggle between video that have same length
        [Header("Drag videoClip HERE")]
        [SerializeField] protected VideoClip _video1;
        [SerializeField] protected VideoClip _video2;
        protected VideoClip _currentVideo;

        public override void UpdateVideo<T>(T newVideo, bool PlayVideoAfterUpdate = true)
        {
            _currentVideo = newVideo as VideoClip;
            _videoPlayer.clip = _currentVideo;
            if (PlayVideoAfterUpdate) PlayVideo();
        }

        protected override void InitVideoPlayer()
        {
            UpdateVideo(_video1);
        }

        [Button]
        public void ToggleVideo()
        {
            if (_currentVideo == _video1)
            {
                UpdateVideo(_video2);
            }
            else if (_currentVideo == _video2)
            {
                UpdateVideo(_video1);
            }
        }
    }
}