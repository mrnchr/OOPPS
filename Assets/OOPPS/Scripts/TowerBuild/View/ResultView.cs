using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

namespace OOPPS.TowerBuild
{
    public class ResultView : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _floorCounterTxt;
        [SerializeField] private TextMeshProUGUI _resCounterTxt;
        [SerializeField] private GameObject _resultPanel;
        [SerializeField] private Button _returnButton;



        public void SetUpResultView(int catchedFloorCnt, int allFloorCnt, int resCnt)
        {
            _floorCounterTxt.text = catchedFloorCnt + " / " + allFloorCnt;
            _resCounterTxt.text = resCnt.ToString();

            ShowResultPanel();
        }
        private void ShowResultPanel()
        {
            _resultPanel.SetActive(true);
        }
        private void HideResultPanel()
        {
            _resultPanel.SetActive(false);
        }


        public void AddButtonListener(Action action)
        {
            UnityAction unityAction = new UnityAction(action);
            _returnButton.onClick.AddListener(unityAction);
        }
        public void RemoveButtonListener(Action action)
        {
            UnityAction unityAction = new UnityAction(action);
           _returnButton.onClick.RemoveListener(unityAction);
        }

    }
}