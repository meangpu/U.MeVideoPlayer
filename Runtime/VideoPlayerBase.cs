using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Meangpu.Video
{
    [RequireComponent(typeof(VideoPlayer))]
    public abstract class VideoPlayerBase : MonoBehaviour
    {
        // need folder name "StreamingAssets" at Assets root, when use streamingAsset unity won' recognize video type, so it need to use string as name
        [SerializeField] protected bool _playOnStart;
        [SerializeField] protected bool _isLooping;
        protected bool _isPlaying;

        [Header("Texture")]
        [SerializeField] protected RawImage _rawImg;
        [SerializeField] protected RenderTexture _mainTexture;
        [SerializeField] protected VideoPlayer _videoPlayer;

        void Start()
        {
            InitVideoPlayer();
            _videoPlayer.isLooping = _isLooping;
            DisplayFirstImage();
            if (_playOnStart) PlayVideo();
            else PauseVideo();
            UpdateUIByVideoPlayState();
        }

        protected abstract void InitVideoPlayer();
        protected abstract void UpdateUIByVideoPlayState();

        protected void DisplayFirstImage()
        {
            _videoPlayer.time = 0;
            _videoPlayer.Play();
            _videoPlayer.Pause();
        }

        public virtual void TogglePausePlay()
        {
            if (_isPlaying) _videoPlayer.Pause();
            else _videoPlayer.Play();
            _isPlaying = !_isPlaying;
            UpdateUIByVideoPlayState();
        }

        public void PlayVideo()
        {
            _videoPlayer.Play();
            _isPlaying = true;
        }

        public void PauseVideo()
        {
            _videoPlayer.Pause();
            _isPlaying = false;
        }
    }
}