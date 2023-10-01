using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Meangpu.Video
{
    [RequireComponent(typeof(VideoPlayer))]
    public abstract class VideoPlayerBase : MonoBehaviour
    {
        // need folder name "StreamingAssets" at Assets root, when use streamingAsset unity won' recognize video type, so it need to use string as name
        [SerializeField] protected bool _isPause;

        [Header("Texture")]
        [SerializeField] protected RawImage _rawImg;
        [SerializeField] protected RenderTexture _mainTexture;
        [SerializeField] protected VideoPlayer _videoPlayer;

        void Start()
        {
            InitVideoPlayer();
            DisplayFirstImage();
            TogglePausePlay();
        }

        protected abstract void InitVideoPlayer();

        protected void DisplayFirstImage()
        {
            _videoPlayer.time = 0;
            _videoPlayer.Play();
            _videoPlayer.Pause();
        }

        public virtual void TogglePausePlay()
        {
            if (_isPause) PlayVid();
            else PauseVid();
            _isPause = !_isPause;
        }

        void PlayVid() => _videoPlayer.Play();
        void PauseVid() => _videoPlayer.Pause();
    }
}