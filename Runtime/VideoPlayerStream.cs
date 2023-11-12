using UnityEngine;

namespace Meangpu.Video
{
    public class VideoPlayerStream : VideoPlayerBase
    {
        [Header("Drag video from 'StreamingAssets' HERE")]
        [SerializeField] string _videoName;
        [SerializeField] string _videoExtension = ".mp4";

        protected override void InitVideoPlayer()
        {
            _rawImg.texture = _mainTexture;
            _videoPlayer.targetTexture = _mainTexture;

            if (string.IsNullOrWhiteSpace(_videoName))
            {
                Debug.Log("<color=red>VideoNameNotSet</color>");
                return;
            }
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, _videoName + _videoExtension);
        }

        public override void UpdateVideo<T>(T newVideo)
        {
            string videoName = newVideo as string;
            if (string.IsNullOrWhiteSpace(videoName))
            {
                Debug.Log("<color=red>VideoNameNotSet</color>");
                return;
            }
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName + _videoExtension);
            PlayVideo();
        }
    }
}