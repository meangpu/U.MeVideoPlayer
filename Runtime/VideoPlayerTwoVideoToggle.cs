using UnityEngine;
using UnityEngine.Video;

namespace Meangpu.Video
{
    public class VideoPlayerTwoVideoToggle : BaseVideoPlayer
    {
        // create for make toggle between video that have same length
        [Header("Drag videoClip HERE")]
        [SerializeField] protected VideoClip _video1;
        [SerializeField] protected VideoClip _video2;

        public override void UpdateVideo<T>(T newVideo)
        {
            _videoPlayer.clip = newVideo as VideoClip;
            PlayVideo();
        }

        protected override void InitVideoPlayer()
        {
            _videoPlayer.clip = _video1;
            _rawImg.texture = _mainTexture;
            _videoPlayer.targetTexture = _mainTexture;
        }
    }
}