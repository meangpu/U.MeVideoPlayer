using UnityEngine;

namespace Meangpu.Video
{
    public class VideoPlayerYoutube : BaseVideoPlayer
    {
        [Header("type video URL HERE")]
        [SerializeField] string _videoURL;

        protected override void InitVideoPlayer()
        {
            _videoPlayer.url = _videoURL;
        }

        public override void UpdateVideo<T>(T newVideo)
        {
            string videoName = newVideo as string;
            if (string.IsNullOrWhiteSpace(videoName))
            {
                Debug.Log("<color=red>VideoNameNotSet</color>");
                return;
            }
            _videoPlayer.url = videoName;
            PlayVideo();
        }

    }
}