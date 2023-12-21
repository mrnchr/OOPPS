using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace OOPPS.TowerBuild
{
    public class GameLoopView : MonoBehaviour
    {
        [SerializeField] private GameObject _controllersPanel;
        [SerializeField] private GameObject _buffsPanel;

        [SerializeField] private TextMeshProUGUI _floorCounterTxt;
        [SerializeField] private GameObject _floorViewObj;

        [SerializeField] private Image _hpImgPref;
        [SerializeField] private GameObject _hpImgContainer;
        private List<Image> _imagesList = new();

        [SerializeField] private Sprite _enableHpSprite;
        [SerializeField] private Sprite _disableHpSprite;


        public void InitGameScreen(int initHpCount, int allFloorCnt)
        {
            InitHpView(initHpCount);
            SetFloorCounter(0, allFloorCnt);

            HideGameScreen();
            ShowBuffsPanel();
        }

        private void InitHpView(int initHpCount)
        {
            for (int i = 0; i < initHpCount; i++)
            {
                _imagesList.Add(Instantiate(_hpImgPref, _hpImgContainer.transform));
            }
            SetHp(initHpCount);
            ShowBuffsPanel();
        }

        internal void HideGameScreen()
        {
            HideControllers();
            HideStatsView();
        }
        internal void HideGameScreen(int _1, int _2, int _3)
        {
            HideGameScreen();
        }
        internal void ShowGameScreen()
        {
            ShowControllers();
            ShowStatsView();
        }
        internal void ShowBuffsPanel()
        {
            _buffsPanel.SetActive(true);
        }
        internal void HideBuffsPanel()
        {
            _buffsPanel.SetActive(false);
        }

        private void ShowControllers()
        {
            _controllersPanel.SetActive(true);
        }
        private void HideControllers()
        {
            _controllersPanel.SetActive(false);
        }


        private void ShowStatsView()
        {
            _hpImgContainer.SetActive(true);
            _floorViewObj.SetActive(true);
        }
        private void HideStatsView()
        {
            _hpImgContainer.SetActive(false);
            _floorViewObj.SetActive(false);
        }


        public void SetFloorCounter(int catchedFloorCnt, int allFloorCnt)
        {
            _floorCounterTxt.text = catchedFloorCnt + " / " + allFloorCnt;
        }

        public void SetHp(int hpValue)
        {
            for (int i = 0; i < _imagesList.Count; i++)
            {
                _imagesList[i].sprite = _disableHpSprite;
                _imagesList[i].color = new Color(1f, 1f, 1f, 0.6156863f);
                if (i + 1 <= hpValue)
                {
                    _imagesList[i].sprite = _enableHpSprite;
                    _imagesList[i].color = new Color(1f, 1f, 1f, 0.9156863f);
                }
            }

        }
    }
}
