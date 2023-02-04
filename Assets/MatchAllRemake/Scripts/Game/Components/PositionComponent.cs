using Entitas;

namespace MatchAll.Game
{
    [GameLogic]
    public sealed class PositionComponent : IComponent
    {
        public int x;
        public int y;
    }
}
