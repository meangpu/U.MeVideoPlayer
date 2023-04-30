using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoFixNew : MonoBehaviour
{
    public bool isPause;
    public string videoName;
    [SerializeField] Button PlayBtn;
    [SerializeField] Image PlayBtnBgImg;
    [SerializeField] GameObject playBtnIcon;
    [Header("Texture")]
    public RawImage _rawImg;
    public VideoPlayer theVideo;
    public RenderTexture _mainTexture;

    void Start()
    {
        theVideo.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
        _rawImg.texture = _mainTexture;
        theVideo.targetTexture = _mainTexture;
        DisplayFirstImage();
        SwitchPlayPause();
    }

    void DisplayFirstImage()
    {
        theVideo.time = 0;
        theVideo.Play();
        theVideo.Pause();
    }


    public void SwitchPlayPause()
    {
        if (isPause)
        {
            PlayVid();
        }
        else
        {
            PauseVid();
        }
        SetBtnVis(!isPause);
        isPause = !isPause;
    }

    void PlayVid()
    {
        theVideo.Play();
    }

    void PauseVid()
    {
        theVideo.Pause();
    }

    void SetBtnVis(bool vis)
    {
        playBtnIcon.SetActive(vis);
    }


}
