using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPPS.TowerBuild
{
    public class Boarders : MonoBehaviour
    {
        [SerializeField] private Transform leftBorder;
        [SerializeField] private Transform rightBorder;


        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;
            return positionX > this.leftBorder.position.x
                   && positionX < this.rightBorder.position.x;
        }

        public bool IsFreeByRight(Vector2 position)
        {
            var positionX = position.x;
            return positionX < this.rightBorder.position.x;
        }
        public bool IsFreeByLeft(Vector2 position)
        {
            var positionX = position.x;
            return positionX > this.leftBorder.position.x;
        }
    }
}
