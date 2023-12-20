using OOPPS.Core.Mvc;
using TMPro;
using UnityEngine;

namespace OOPPS.City.UI.InfoField
{
    public class InfoView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}