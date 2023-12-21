using TMPro;
using UnityEngine;

namespace OOPPS.City.UI.ResourceBar
{
    public class EnergyBarView : ResourceView
    {
        [SerializeField] private TMP_Text _time;

        public void SetTime(string text)
        {
            _time.text = text;
        }
    }
}