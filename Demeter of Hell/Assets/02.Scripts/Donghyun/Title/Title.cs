using UnityEngine;
using DG.Tweening;
using Donghyun.UI.Animation;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] private UIInformation characterInfo;
    [SerializeField] private UIInformation hornInfo;
    [SerializeField] private UIInformation hellTextInfo;
    [SerializeField] private UIInformation riceInfo;
    [SerializeField] private UIInformation demeterTextInfo;
    [SerializeField] private UIInformation hoeInfo;
    [SerializeField] private UIInformation gameStartInfo;

    private void Start()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(characterInfo.rectTransform.DOScale(characterInfo.end, characterInfo.tweenDuration).SetEase(characterInfo.EaseType))
            .Append(hellTextInfo.rectTransform.DOAnchorPos(hellTextInfo.end, hellTextInfo.tweenDuration).SetEase(hellTextInfo.EaseType))
            .Append(hornInfo.rectTransform.DOScale(hornInfo.end, hornInfo.tweenDuration).SetEase(hornInfo.EaseType))
            .Append(demeterTextInfo.rectTransform.DOScale(demeterTextInfo.end, demeterTextInfo.tweenDuration).SetEase(demeterTextInfo.EaseType))
            .Join(hoeInfo.rectTransform.DOScale(hoeInfo.end, hoeInfo.tweenDuration).SetEase(hoeInfo.EaseType).SetDelay(0.2f))
            .Join(riceInfo.rectTransform.DOScale(riceInfo.end, riceInfo.tweenDuration).SetEase(riceInfo.EaseType).SetDelay(0.3f))
            .Append(gameStartInfo.rectTransform.GetComponent<Image>().DOFade(1.0f, gameStartInfo.tweenDuration))
            .Join(gameStartInfo.rectTransform.DOScale(gameStartInfo.end, gameStartInfo.tweenDuration).SetEase(gameStartInfo.EaseType).SetLoops(-1, LoopType.Yoyo));

    }
}
