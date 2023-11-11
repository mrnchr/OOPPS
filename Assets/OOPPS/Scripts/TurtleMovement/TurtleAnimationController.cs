using OOPPS.Core;

namespace OOPPS
{
    public class TurtleAnimationController : IUpdatable
    {
        private readonly TurtleView _turtle;

        public TurtleAnimationController(TurtleView turtle)
        {
            _turtle = turtle;
        }

        public void Update()
        {
            // TODO: write when there will be animations
        }
    }
}