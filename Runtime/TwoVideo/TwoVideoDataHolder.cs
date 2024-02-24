using UnityEngine;
using VInspector;

namespace Meangpu.Video
{
    public class TwoVideoDataHolder : MonoBehaviour
    {
        public TwoVideoData TwoVideoData;

        [Button]
        public void InvokeUpdateVideo()
        {
            ActionTwoVideoPlayer.OnUpdateVideo?.Invoke(TwoVideoData);
        }
    }
}