using OOPPS.Core;
using UnityEngine;

namespace OOPPS
{
    public class TurtleMovementController : IUpdatable
    {
        private readonly TurtleView _turtle;
        private readonly MoveButton _back;
        private readonly MoveButton _forward;
        private readonly TurtleConfig _config;

        public TurtleMovementController(TurtleView turtle, MoveButton back, MoveButton forward, TurtleConfig config)
        {
            _turtle = turtle;
            _back = back;
            _forward = forward;
            _config = config;
        }


        public void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            float direction = 0;
            if (_back.IsClickHold)
                direction -= 1;
            if (_forward.IsClickHold)
                direction += 1;

            _turtle.Rb.velocity = Vector3.right * (direction * _config.Speed);
        }
    }
}