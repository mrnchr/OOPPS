using System;
using UnityEngine;

namespace OOPPS.City
{
    [Serializable]
    public class PlayingResources
    {
        [SerializeField] private float _woods;
        [SerializeField] private float _coins;
        [SerializeField] private float _diamonds;

        public float Woods
        {
            get => _woods;
            set => _woods = value;
        }

        public float Coins
        {
            get => _coins;
            set => _coins = value;
        }

        public float Diamonds
        {
            get => _diamonds;
            set => _diamonds = value;
        }

        public void Copy(PlayingResources from)
        {
            _woods = from.Woods;
            _coins = from.Coins;
            _diamonds = from.Diamonds;
        }
    }
}