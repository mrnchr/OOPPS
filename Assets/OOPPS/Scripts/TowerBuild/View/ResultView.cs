using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace OOPPS.TowerBuild
{
    public class ResultView : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _floorCounterTxt;
        [SerializeField] private TextMeshProUGUI _resCounterTxt;
        [SerializeField] private GameObject _resultPanel;


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


    }
}