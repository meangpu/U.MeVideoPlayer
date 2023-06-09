using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerMeangpu : MonoBehaviour
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
        // read from streaming asset part
        theVideo.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
        _rawImg.texture = _mainTexture;
        theVideo.targetTexture = _mainTexture;
        DisplayFirstImage();
        TogglePausePlay();
        PlayBtn.onClick.AddListener(TogglePausePlay);
    }

    void DisplayFirstImage()
    {
        theVideo.time = 0;
        theVideo.Play();
        theVideo.Pause();
    }


    public void TogglePausePlay()
    {
        if (isPause) PlayVid();
        else PauseVid();

        SetBtnVis(!isPause);
        isPause = !isPause;
    }

    void PlayVid() => theVideo.Play();

    void PauseVid() => theVideo.Pause();

    void SetBtnVis(bool vis) => playBtnIcon.SetActive(vis);


}
