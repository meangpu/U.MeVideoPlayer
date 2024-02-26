using VInspector;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

namespace Meangpu.Video
{
    public abstract class BaseVideoPlayer : MonoBehaviour
    {
        // need folder name "StreamingAssets" at Assets root, when use streamingAsset unity won' recognize video type, so it need to use string as name
        [SerializeField] protected bool _playOnStart;
        [SerializeField] protected bool _isLooping = true;
        protected bool _isPlaying;

        [Header("Video Source")]
        [SerializeField] protected VideoPlayer _videoPlayer;
        [SerializeField] protected RawImage _rawImg;
        [SerializeField] protected RenderTexture _mainTexture;

        [Header("UIButton optional")]
        [SerializeField] protected GameObject _playBtnIcon;
        [SerializeField] protected Slider _playbackSlider;
        [SerializeField] protected TMP_Text _timestampText;
        protected bool _isSliderSliding;

        void Start()
        {
            UpdateVideoTexture();
            InitVideoPlayer();
            _videoPlayer.isLooping = _isLooping;
            DisplayFirstImage();

            InitAllUI();

            if (_playOnStart) PlayVideo();
            else PauseVideo();
        }

        protected void InitAllUI()
        {
            UpdateUI();
            SetupSliderUI();
            UpdateTimeText();
        }

        void SetupSliderUI()
        {
            if (_playbackSlider == null) return;

            _playbackSlider.minValue = 0;
            _playbackSlider.maxValue = 1;

            _playbackSlider.onValueChanged.AddListener(SetVideoToNewTime);
        }

        private void UpdateTimeText()
        {
            if (_timestampText != null)
            {
                _timestampText.SetText($"{TimeUtility.ConvertSecondsToMinute((int)_videoPlayer.time)}/{TimeUtility.ConvertSecondsToMinute((int)_videoPlayer.length)}");
            }
        }

        public void OnStartDragEvent()
        {
            _isSliderSliding = true;
            PauseNoWithNoUI();
        }

        public void OnEndDragEvent()
        {
            _isSliderSliding = false;
            PlayVideo();
        }

        public void SetVideoToNewTime(float value)
        {
            _videoPlayer.time = _videoPlayer.length * value;
        }

        public void SetSliding(bool newState) => _isSliderSliding = newState;

        protected abstract void InitVideoPlayer();
        public abstract void UpdateVideo<T>(T newVideo, bool PlayVideoAfterUpdate = true);

        protected void UpdateVideoTexture()
        {
            _rawImg.texture = _mainTexture;
            _videoPlayer.targetTexture = _mainTexture;
        }

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
            UpdateUI();
        }

        public void PauseVideo()
        {
            _videoPlayer.Pause();
            _isPlaying = false;
            UpdateUI();
        }

        public void PauseNoWithNoUI()
        {
            _videoPlayer.Pause();
            _isPlaying = false;
        }

        [Button]
        public void RestartVideo()
        {
            _videoPlayer.time = 0;
            PlayVideo();
        }

        protected float GetVideoPercent() => (float)(_videoPlayer.time / _videoPlayer.length);

        private void Update()
        {
            if (!_isSliderSliding && _playbackSlider != null)
            {
                _playbackSlider.SetValueWithoutNotify(GetVideoPercent());
            }
            UpdateTimeText();
        }

    }
}