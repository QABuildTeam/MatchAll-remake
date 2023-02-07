using Entitas;

namespace MatchAll.Game
{
    [Game]
    public class BoundsComponent : IComponent
    {
        public float xMin;
        public float yMin;
        public float xMax;
        public float yMax;
    }
}
