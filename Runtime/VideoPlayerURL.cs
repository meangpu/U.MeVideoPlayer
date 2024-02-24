using UnityEngine;

namespace Meangpu.Video
{
    public class VideoPlayerURL : BaseVideoPlayer
    {
        [Header("type video URL HERE")]
        [SerializeField] string _videoURL;

        protected override void InitVideoPlayer()
        {
            UpdateVideo(_videoURL, false);
        }

        public override void UpdateVideo<T>(T newVideo, bool PlayVideoAfterUpdate = true)
        {
            string videoName = newVideo as string;
            if (string.IsNullOrWhiteSpace(videoName))
            {
                Debug.Log("<color=red>VideoNameNotSet</color>");
                return;
            }
            _videoPlayer.url = videoName;
            if (PlayVideoAfterUpdate) PlayVideo();
            InitAllUI();
        }

    }
}