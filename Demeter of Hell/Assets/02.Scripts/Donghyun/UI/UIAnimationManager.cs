using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;

namespace Donghyun.UI.Animation
{
    [Serializable]
    public class UIInfomation
    {
        public RectTransform rectTransform;
        public float startPosY, endPosY;
        public float tweenDuration;
    }

    public class UIAnimationManager : MonoBehaviour
    {
        private static UIAnimationManager instance;
        private UIInfomation UIInfo;

        public static UIAnimationManager Instance
        {
            get
            {
                if (instance == null) instance = new UIAnimationManager();
                return instance;
            }
        }

        private void Awake()
        {
            //인스턴스가 비어있다면 할당해주고, 
            //해당 오브젝트를 씬 이동간 파괴하지 않게함
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            // 인스턴스가 이미 할당돼있다면(2개 이상이라면) 파괴
            else
            {
                Destroy(gameObject);
            }
        }

        public void Init(UIInfomation UIInfo)
        {
            this.UIInfo = UIInfo;
        }

        public void InitPositon()
        {
            Debug.Log("UIAnimation - 초기 포지션 조정");
            UIInfo.rectTransform.localPosition = new Vector3(UIInfo.rectTransform.localPosition.x, UIInfo.startPosY, UIInfo.rectTransform.localPosition.z);
        }

        public void OpenUI(Action callBack)
        {
            callBack();
            Debug.Log("UIAnimation - UI 열림");
            UIInfo.rectTransform.DOAnchorPosY(UIInfo.endPosY, UIInfo.tweenDuration).SetUpdate(true);
        }

        public void CloseUI(Action callBack)
        {
            Debug.Log("UIAnimation - UI 닫힘");
            UIInfo.rectTransform.DOAnchorPosY(UIInfo.startPosY, UIInfo.tweenDuration).SetUpdate(true);

            StartCoroutine(InvokeActionRoutine(callBack));
        }

        private IEnumerator InvokeActionRoutine(Action callBack)
        {
            yield return new WaitForSecondsRealtime(UIInfo.tweenDuration);

            Debug.Log("UIAnimation - 지연 실행");
            callBack?.Invoke(); // Action 호출
        }
    }
}
