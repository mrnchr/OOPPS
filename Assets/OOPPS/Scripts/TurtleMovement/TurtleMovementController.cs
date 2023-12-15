using OOPPS.Core;
using UnityEngine;

namespace OOPPS.TowerBuild
{
    public class TurtleMovementController : IUpdatable
    {
        private readonly TurtleView _turtle;
        private readonly MoveButton _back;
        private readonly MoveButton _forward;
        private readonly TurtleConfig _config;

        private Boarders _boarders;

        private bool _canMove;

        public TurtleMovementController(TurtleView turtle, MoveButton back, MoveButton forward, TurtleConfig config, Boarders boarders)
        {
            EnableMovement();
            _turtle = turtle;
            _back = back;
            _forward = forward;
            _config = config;
            _boarders = boarders;
        }

        public void EnableMovement()
        {
            _canMove = true;
        }

        public void DisableMovement()
        {
            _canMove = false;
        }


        public void Update()
        {
            if (_canMove)
            {
                HandleMovement();
            }

        }

        private void HandleMovement()
        {
            float direction = 0;
            if (_back.IsClickHold)
                direction -= 1;
            if (_forward.IsClickHold)
                direction += 1;

            _turtle.RotateModel(direction);

            if (_boarders.IsFreeByLeft(_turtle.transform.position) && direction < 0 || _boarders.IsFreeByRight(_turtle.transform.position) && direction > 0)
            {
                _turtle.Rb.velocity = Vector3.right * (direction * _config.Speed);
            }
            else
            {
                _turtle.Rb.velocity = Vector3.right * 0;
            }





        }
    }
}