using UnityEngine;
using UnityEngine.Video;

namespace Meangpu.Video
{
    [System.Serializable]
    public class TwoVideoData
    {
        [SerializeField] VideoClip _video1;
        [SerializeField] VideoClip _video2;
        [SerializeField] bool _nowIsVideo1 = true;

        public VideoClip Video1 => _video1;
        public VideoClip Video2 => _video2;
        public bool NowIsVideo1 => _nowIsVideo1;

        public void DoToggleNowIsVideo1()
        {
            _nowIsVideo1 = !_nowIsVideo1;
        }

        public VideoClip GetNowVideo()
        {
            if (_nowIsVideo1) return _video1;
            else return _video2;
        }

        public VideoClip GetToggleVideo()
        {
            _nowIsVideo1 = !_nowIsVideo1;
            return GetNowVideo();
        }

        public void SetNowIsVideo1() => _nowIsVideo1 = true;
        public void SetNowIsVideo2() => _nowIsVideo1 = false;
    }
}