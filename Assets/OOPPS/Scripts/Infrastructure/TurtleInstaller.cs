using OOPPS.Core;
using UnityEngine;

namespace OOPPS
{
    public class TurtleInstaller : MonoInstaller
    {
        [SerializeField] private Updater _updater;
        [SerializeField] private TurtleView _turtle;
        [SerializeField] private MoveButton _back;
        [SerializeField] private MoveButton _forward;
        [SerializeField] private TurtleConfig _config;
        
        public override void InstallBindings()
        {
            var moveCtrl = new TurtleMovementController(_turtle, _back, _forward, _config);
            var animCtrl = new TurtleAnimationController(_turtle);

            _container
                .BindAll(moveCtrl)
                .BindAll(animCtrl)
                .BindAll(_updater);
        }
    }
}