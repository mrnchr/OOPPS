using System.Collections.Generic;
using OOPPS.Core.Mvc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OOPPS.City.Building
{
    public class BuildingView : MonoBehaviour, IView
    {
        [SerializeField] private BuildingConfig _config;

        [SerializeField] private List<StageView> _stages;

        [SerializeField] private BuildingInteraction _placeInteraction;
        [SerializeField] private BuildingInteraction _earnInteraction;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _time;
        [SerializeField] private TMP_Text _money;

#if UNITY_EDITOR
        [Header("Runtime")]
        [SerializeField] private BuildingModel _model;

        public void SetModel(BuildingModel model)
        {
            _model = model;
        }
#endif

        private BuildingController _controller;

        public BuildingConfig Config => _config;

        private void OnEnable()
        {
            _placeInteraction.OnInteracted += InteractWithPlace;
            _earnInteraction.OnInteracted += InteractWithEarn;
        }

        private void OnDisable()
        {
            _placeInteraction.OnInteracted -= InteractWithPlace;
            _earnInteraction.OnInteracted -= InteractWithEarn;
        }

        public void SetController(BuildingController controller)
        {
            _controller = controller;
        }

        public void InteractWithPlace()
        {
            _controller.RequestBuild();
        }

        public void InteractWithEarn()
        {
            _controller.CollectMoney();
        }

        public void SetActiveStage(BuildingStage stage, bool value)
        {
            _stages.Find(x => x.Id == stage).gameObject.SetActive(value);
        }

        public void SetPrice(string text)
        {
            _price.text = text;
        }

        public void SetTimeRatio(float value)
        {
            _time.fillAmount = value;
        }

        public void SetMoney(string text)
        {
            _money.text = text;
        }

        public void Hide()
        {
            foreach (StageView stage in _stages)
            {
                stage.gameObject.SetActive(false);
            }
        }
    }
}