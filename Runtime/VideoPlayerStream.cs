using UnityEditor;
using UnityEngine;

namespace Meangpu.Video
{
    public class VideoPlayerStream : VideoPlayerWithUI
    {
        [Header("Drag video from 'StreamingAssets' HERE")]
        [SerializeField] DefaultAsset _video;
        [SerializeField] string _videoExtension = ".mp4";

        protected override void InitVideoPlayer()
        {
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, _video.name + _videoExtension);
            _rawImg.texture = _mainTexture;
            _videoPlayer.targetTexture = _mainTexture;
        }

        public override void UpdateVideo<T>(T newVideo)
        {
            DefaultAsset newVideoAsset = newVideo as DefaultAsset;
            string videoName = newVideoAsset.name;
            _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName + _videoExtension);
            PlayVideo();
        }
    }
}