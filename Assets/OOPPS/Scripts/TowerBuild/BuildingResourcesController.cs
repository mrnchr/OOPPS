using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OOPPS.Persistence;

namespace OOPPS.TowerBuild
{
    public class BuildingResourcesController
    {
        private float _crntWoodCount;

        public void SetWoods(float resCount)
        {
            _crntWoodCount = resCount;
        }

        public void AddWoods(float addedCnt)
        {
            _crntWoodCount += addedCnt;
        }

        public float GetWoods()
        {
            return _crntWoodCount;
        }

    }
}