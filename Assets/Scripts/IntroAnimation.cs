using System;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroAnimation : MonoBehaviour
{
    [SerializeField] private Image introTextImage;
    [SerializeField] private Image introBackImage;
    [SerializeField] private TextMeshProUGUI introText;

    [SerializeField] private float introTextImageFadeTime = 1.2f;
    [SerializeField] private float introBackImageFadeTime;
    [SerializeField] private float introTextFadeTime;

    private bool _canClick;

    private void Awake()
    {
        introText.DOFade(0, 0);
        introText.gameObject.SetActive(false);


        introTextImage.DOFade(0, introTextImageFadeTime).OnComplete((() =>
        {
            introBackImage.DOFade(0, introBackImageFadeTime).OnComplete((() =>
            {
                introText.gameObject.SetActive(true);
                introText.DOFade(1, introTextFadeTime).OnComplete((() => { })).SetLoops(-1, LoopType.Yoyo)
                    .SetEase(Ease.InOutSine);
                Observable.Timer(TimeSpan.FromSeconds(introTextFadeTime * 2f)).Subscribe((l =>
                {
                    _canClick = true;
                }));
            }));
        }));
    }

    private void Update()
    {
        if (!_canClick) return;
        if (Input.anyKeyDown) SceneManager.LoadSceneAsync("Game");
    }
}