using UnityEngine;
using EasyButtons;

namespace Meangpu.Video
{
    public abstract class VideoPlayerWithUI : VideoPlayerBase
    {
        [Header("uiButton")]
        [SerializeField] GameObject _playBtnIcon;

        [Button]
        public override void TogglePausePlay()
        {
            base.TogglePausePlay();
            UpdateUIByVideoPlayState();
        }

        protected override void UpdateUIByVideoPlayState() => _playBtnIcon.SetActive(!_isPlaying);
    }
}