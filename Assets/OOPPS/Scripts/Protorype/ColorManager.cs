using System.Collections.Generic;
using UnityEngine;

namespace OOPPS.TowerBuild
{
    public class ColorManager : MonoBehaviour
    {
        [SerializeField] private List<Material> _floorMaterials = new();

        public List<Material> GetRandomMaterials()
        {
            var ind = Random.Range(0, _floorMaterials.Count / 2);

            List<Material> list = new();
            list.Add(_floorMaterials[ind * 2]);
            list.Add(_floorMaterials[ind * 2 + 1]);

            return list;
        }
    }
}