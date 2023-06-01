using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutImage : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float fadeDelay = 0.1f;

    private bool _hasFaded;

    public void ToggleFade()
    {
        if (!_hasFaded)
            FadeIn();
        else
            FadeOut();
    }

    public void FadeOut() => fadeImage.DOFade(1, fadeDuration).SetDelay(fadeDelay).OnComplete(() => _hasFaded = false);
    public void FadeIn() => fadeImage.DOFade(0, fadeDuration).SetDelay(fadeDelay).OnComplete((() => _hasFaded = true));
}