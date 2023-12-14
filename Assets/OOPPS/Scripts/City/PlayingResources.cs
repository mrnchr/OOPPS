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
        [SerializeField] private float _energy;

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

        public float Energy
        {
            get => _energy;
            set => _energy = value;
        }

        public void Copy(PlayingResources from)
        {
            _woods = from.Woods;
            _coins = from.Coins;
            _diamonds = from.Diamonds;
            _energy = from.Energy;
        }
    }
}