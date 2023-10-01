using UnityEditor;
using UnityEngine;

namespace Meangpu.Video
{
    public class VideoPlayerStream : VideoPlayerBase
    {
        [Header("Drag video from 'StreamingAssets' HERE")]
#if UNITY_EDITOR
        [SerializeField] DefaultAsset _video;
#endif
        [SerializeField] string _videoExtension = ".mp4";

        protected override void InitVideoPlayer()
        {
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, _video.name + _videoExtension);
            _rawImg.texture = _mainTexture;
            _videoPlayer.targetTexture = _mainTexture;
        }

        public override void UpdateVideo<T>(T newVideo)
        {
            string videoName = newVideo as string;
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName + _videoExtension);
            PlayVideo();
        }
    }
}