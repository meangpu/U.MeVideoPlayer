using UnityEngine;

namespace Meangpu.Video
{
    public class VideoPlayerStream : BaseVideoPlayer
    {
        [Header("type video name from 'StreamingAssets' HERE")]
        [SerializeField] string _videoName;
        [SerializeField] string _videoExtension = ".mp4";

        protected override void InitVideoPlayer()
        {
            if (string.IsNullOrWhiteSpace(_videoName))
            {
                Debug.Log("<color=red>VideoNameNotSet</color>");
                return;
            }
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, _videoName + _videoExtension);
        }

        public override void UpdateVideo<T>(T newVideo, bool PlayVideoAfterUpdate = true)
        {
            string videoName = newVideo as string;
            if (string.IsNullOrWhiteSpace(videoName))
            {
                Debug.Log("<color=red>VideoNameNotSet</color>");
                return;
            }
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName + _videoExtension);
            if (PlayVideoAfterUpdate) PlayVideo();
        }
    }
}