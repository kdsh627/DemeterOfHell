using UnityEngine;
using DG.Tweening;
using Donghyun.UI.Animation;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] private UIInformation hornInfo;
    [SerializeField] private UIInformation riceInfo;
    [SerializeField] private UIInformation TextInfo;
    [SerializeField] private UIInformation hoeInfo;
    [SerializeField] private UIInformation gameStartInfo;
    [SerializeField] private UIInformation titleInfo;

    [SerializeField] GameObject StartButton;
    private void Start()
    {
        Sequence seq = DOTween.Sequence();

        /*Append(characterInfo.rectTransform.DOScale(characterInfo.end, characterInfo.tweenDuration).SetEase(characterInfo.EaseType))
            .Append(hellTextInfo.rectTransform.DOAnchorPos(hellTextInfo.end, hellTextInfo.tweenDuration).SetEase(hellTextInfo.EaseType))
            .Append(hornInfo.rectTransform.DOScale(hornInfo.end, hornInfo.tweenDuration).SetEase(hornInfo.EaseType))
            .Append(demeterTextInfo.rectTransform.DOScale(demeterTextInfo.end, demeterTextInfo.tweenDuration).SetEase(demeterTextInfo.EaseType))
            .Join(hoeInfo.rectTransform.DOScale(hoeInfo.end, hoeInfo.tweenDuration).SetEase(hoeInfo.EaseType).SetDelay(0.2f))
            .Join(riceInfo.rectTransform.DOScale(riceInfo.end, riceInfo.tweenDuration).SetEase(riceInfo.EaseType).SetDelay(0.3f))
        */

        seq.Append(TextInfo.rectTransform.DOAnchorPos(TextInfo.end, TextInfo.tweenDuration).SetEase(TextInfo.EaseType))
            .Append(riceInfo.rectTransform.DOScale(riceInfo.end, riceInfo.tweenDuration).SetEase(riceInfo.EaseType))
            .Join(hoeInfo.rectTransform.DOScale(hoeInfo.end, hoeInfo.tweenDuration).SetEase(hoeInfo.EaseType).SetDelay(0.1f))
            .Append(hornInfo.rectTransform.DOScaleY(hornInfo.end.y, hornInfo.tweenDuration).SetEase(hornInfo.EaseType))
            .Append(gameStartInfo.rectTransform.GetComponent<Image>().DOFade(1.0f, gameStartInfo.tweenDuration).OnComplete(() => { StartButton.SetActive(true); }))
            .Join(gameStartInfo.rectTransform.DOScale(gameStartInfo.end, gameStartInfo.tweenDuration).SetEase(gameStartInfo.EaseType).SetLoops(-1, LoopType.Yoyo))
            .Join(titleInfo.rectTransform.DOAnchorPos(titleInfo.end, titleInfo.tweenDuration).SetEase(titleInfo.EaseType).SetLoops(-1, LoopType.Yoyo));

    }
}
