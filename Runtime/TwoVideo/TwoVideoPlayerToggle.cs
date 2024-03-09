using UnityEngine;
using UnityEngine.Video;
using VInspector;

namespace Meangpu.Video
{
    public class TwoVideoPlayerToggle : BaseVideoPlayer
    {
        // create for make toggle between video that have same length
        [Header("Drag VideoClip HERE")]
        [SerializeField] protected TwoVideoData _videoData;

        void OnEnable()
        {
            ActionTwoVideoPlayer.OnUpdateVideo += UpdateTwoVideoData;
        }
        void OnDisable()
        {
            ActionTwoVideoPlayer.OnUpdateVideo -= UpdateTwoVideoData;
        }

        public override void UpdateVideo<T>(T newVideo, bool PlayVideoAfterUpdate = true)
        {
            _videoPlayer.clip = newVideo as VideoClip;
            InitAllUI();

            if (PlayVideoAfterUpdate) PlayVideo();
        }

        public void UpdateTwoVideoData(TwoVideoData newData)
        {
            _videoData = newData;
            InitVideoPlayer();
        }

        protected override void InitVideoPlayer()
        {
            UpdateVideo(_videoData.GetNowVideo());
        }

        [Button]
        public virtual void ToggleVideo()
        {
            ReplaceNewVideoWithSameFrame(_videoData.GetToggleVideo());
        }

        public virtual void ReplaceNewVideoWithSameFrame(VideoClip newVideo)
        {
            long _currentTime = _videoPlayer.frame;
            _videoPlayer.clip = newVideo;
            _videoPlayer.frame = _currentTime;
        }

        public void SetToVideo1() => _videoData.SetNowIsVideo1();
        public void SetToVideo2() => _videoData.SetNowIsVideo2();
    }
}