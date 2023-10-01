using UnityEngine;
using UnityEngine.UI;

namespace Meangpu.Video
{
    public abstract class VideoPlayerWithUI : VideoPlayerBase
    {
        [Header("uiButton")]
        [SerializeField] Button _playBtn;
        [SerializeField] Image _playBtnBgImg;
        [SerializeField] GameObject _playBtnIcon;

        void SetBtnVis(bool vis) => _playBtnIcon.SetActive(vis);

        public override void TogglePausePlay()
        {
            base.TogglePausePlay();
            SetBtnVis(!_isPause);
        }
    }
}