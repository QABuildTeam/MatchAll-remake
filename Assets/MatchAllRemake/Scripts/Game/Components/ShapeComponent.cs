using Entitas;

namespace MatchAll.Game
{
    [GameLogic]
    public sealed class ShapeComponent : IComponent
    {
        public ShapeType shape;
    }
}
