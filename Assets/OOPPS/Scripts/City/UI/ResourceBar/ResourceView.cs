using OOPPS.Core.Mvc;
using TMPro;
using UnityEngine;

namespace OOPPS.City.UI.ResourceBar
{
    public class ResourceView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}