using System;
using UnityEngine;
using UnityEngine.UI;
using Donghyun.UI.Animation;
using Types;

namespace Donghyun.UI.Option
{
    [Serializable]
    public class ButtonInfo //버튼 기본 이미지와 누를 때 이미지
    {
        public Image button;
        public GameObject Panel;
        public Sprite defaultImage;
        public Sprite pressedImage;
    }

    public class OptionUI : MonoBehaviour
    {
        [Header("------Option UI Panel-----")]
        [SerializeField] private GameObject optionPanel;
        [SerializeField] private GameObject darkPanel;

        [Header ("------Buttons-----")]
        [SerializeField] private ButtonInfo[] buttons;

        [Header("------State-----")]
        [SerializeField] private OptionState currentState;

        [Header("-----UI Animation Info------")]
        [SerializeField] private UIInformation UIInfo;

        private bool isOpen;

        public void Awake()
        {
            //디폴트는 그래픽 버튼이 눌린 상태
            currentState = OptionState.Graphic;

            darkPanel.SetActive(false);
            optionPanel.SetActive(false);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Panel.SetActive(false);
            }

            isOpen = false;
        }

        public void ClickOptionButton()
        {
            if (!isOpen)
            {
                OpenOptionPanel();
            }
            else
            {
                CloseOptionPanel();
            }
            isOpen = !isOpen;
        }

        private void OpenOptionPanel()
        {
            UIAnimationManager.OpenUI(() =>
            {
                darkPanel.SetActive(true);
                optionPanel.SetActive(true);

                ChangeUIState(OptionState.Graphic);
                Time.timeScale = 0.0f;
            }, UIInfo, AnimationType.Slide);
        }

        private void CloseOptionPanel()
        {
            UIAnimationManager.CloseUI(()=>
            {
                darkPanel.SetActive(false);
                optionPanel.SetActive(false);
                Time.timeScale = 1.0f;
            }, UIInfo, AnimationType.Slide);
        }
         
        //현재 눌린 버튼에 해당하는 옵션을 띄우는 함수
        private void ChangeUIState(OptionState state)
        {
            ButtonInfo currentButton = buttons[(int)currentState];

            //이전 패널 닫기
            currentButton.Panel.SetActive(false);

            //이전에 눌린 버튼은 디폴트 상태로 변경
            currentButton.button.sprite = currentButton.defaultImage;
            currentButton.button.SetNativeSize();

            currentState = state;   
            currentButton = buttons[(int)currentState];

            //현재 패널 열기
            currentButton.Panel.SetActive(true);

            //새롭게 눌린 버튼의 이미지를 눌린 상태로 바꿔줌
            currentButton.button.sprite = currentButton.pressedImage;
            currentButton.button.SetNativeSize();
        }

        public void PressedGrphicButton()
        {
            ChangeUIState(OptionState.Graphic);
        }

        public void PressedSoundButton()
        {
            ChangeUIState(OptionState.Sound);
        }

        public void PressedExitButton()
        {
            ChangeUIState(OptionState.Exit);
        }
    }
}
