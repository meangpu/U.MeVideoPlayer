using System;
using EasyButtons;
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

        [Header("UIButton optional")]
        [SerializeField] protected GameObject _playBtnIcon;

        void Start()
        {
            InitVideoPlayer();
            _videoPlayer.isLooping = _isLooping;
            DisplayFirstImage();
            if (_playOnStart) PlayVideo();
            else PauseVideo();
            UpdateUI();
        }

        protected abstract void InitVideoPlayer();
        public abstract void UpdateVideo<T>(T newVideo);

        protected void DisplayFirstImage()
        {
            _videoPlayer.time = 0;
            _videoPlayer.Play();
            _videoPlayer.Pause();
        }

        [Button]
        public void TogglePausePlay()
        {
            if (_isPlaying) _videoPlayer.Pause();
            else _videoPlayer.Play();
            _isPlaying = !_isPlaying;
            UpdateUI();
        }

        protected void UpdateUI()
        {
            if (_playBtnIcon == null) return;
            _playBtnIcon?.SetActive(!_isPlaying);
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