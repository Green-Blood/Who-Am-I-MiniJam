using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroAnimation : MonoBehaviour
{
    [SerializeField] private Image introTextImage;
    [SerializeField] private Image introBackImage;
    [SerializeField] private TextMeshProUGUI introText;

    [SerializeField] private float introTextImageFadeTime = 1.2f;
    [SerializeField] private float introBackImageFadeTime;
    [SerializeField] private float introTextFadeTime;

    private void Awake()
    {
        introText.DOFade(0, 0);
        introText.gameObject.SetActive(false);


        introTextImage.DOFade(0, introTextImageFadeTime).OnComplete((() =>
        {
            introBackImage.DOFade(0, introBackImageFadeTime).OnComplete((() =>
            {
                introText.gameObject.SetActive(true);
                introText.DOFade(1, introTextFadeTime).OnComplete((() => { })).SetLoops(2, LoopType.Yoyo)
                    .SetEase(Ease.InOutSine);
            }));
        }));
    }
}